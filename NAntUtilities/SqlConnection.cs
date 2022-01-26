using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace NAntUtilities
{
	/// <summary>
	/// This class provides methods for executing SQL commands and queries.
	/// </summary>
	/// <remarks>
	/// Implements <see cref="System.IDisposable">IDisposable</see>
	/// </remarks>
	/// <example>
	/// <code>
	/// using (var sql = new NAntUtilities.Sql()) {
	/// 	sql.Server = "localhost";
	/// 	sql.InitializeConnection();
	/// 	sql.ExecuteNonQuery("INSERT INTO ...");
	/// }
	/// </code>
	/// </example>
	public class Sql : IDisposable
	{
		#region IDisposable

		/// <summary>
		/// Has been disposed.
		/// </summary>
		private bool disposed = false;

		/// <summary>
		/// Call dispose without disposing properly.
		/// </summary>
		~Sql()
		{
			Dispose(false);
		}

		/// <summary>
		/// Dispose all managed resources.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Dispose all managed resources.
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (disposed == true)
				return;

			if (disposing)
			{
				// Dispose of managed objects
				connectionString = null;
				UserID = null;
				Password = null;

				server.ConnectionContext.Disconnect();
				SqlConnection.ClearPool(sqlConnection);
				sqlConnection.Dispose();

				connected = false;
			}

			disposed = true;
		}

		#endregion

		#region Public Fields

		/// <summary>
		/// The SQL server to connect to.
		/// </summary>
		public string Server { get; set; }

		/// <summary>
		/// The inital catalog to connect to.
		/// </summary>
		public string InitialCatalog { get; set; }

		/// <summary>
		/// The user to use to connect to the server when using SQL authentication.
		/// </summary>
		public string UserID { get; set; }

		/// <summary>
		/// The password to use to connect to the server when using SQL authentication.
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// The connection state of the sql connection and server connection.
		/// </summary>
		public bool Connected { get { return this.connected; } }

		/// <summary>
		/// Enables/disables IntegratedSecurity in the connection string.
		/// </summary>
		public bool IntegratedSecurity { get; set; } = true;

		/// <summary>
		/// Enables/disables Pooling in the connection string.
		/// </summary>
		public bool Pooling { get; set; } = false;

		/// <summary>
		/// TrustServerCertificate bypasses the SQL server certificate check.
		/// </summary>
		public bool TrustServerCertificate { get; set; } = false;

		#endregion

		#region Private Fields

		/// <summary>
		/// The connection state of the sql connection and server connection.
		/// </summary>
		private bool connected = false;

		/// <summary>
		/// The generated connection string based on the class parameters.
		/// </summary>
		private string connectionString = "";

		/// <summary>
		/// The server connection object.
		/// </summary>
		private Server server = null;

		/// <summary>
		/// The sql connection object.
		/// </summary>
		private SqlConnection sqlConnection = null;

		#endregion

		/// <summary>
		/// Generate a SQL connection string based on the class parameters.
		/// </summary>
		/// <exception cref="ArgumentException"></exception>
		public void GenerateConnectionString()
		{
			if (string.IsNullOrEmpty(Server))
				throw new ArgumentException("Server must not be null");

			if (IntegratedSecurity && (!string.IsNullOrEmpty(UserID) || !string.IsNullOrEmpty(Password)))
				throw new ArgumentException("Integrated security cannot be used with UserID and password.");

			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
			builder.DataSource = Server;
			builder.IntegratedSecurity = IntegratedSecurity;
			builder.Pooling = Pooling;

			if (!string.IsNullOrEmpty(InitialCatalog))
				builder.InitialCatalog = InitialCatalog;

			if (!string.IsNullOrEmpty(UserID))
				builder.UserID = UserID;

			if (!string.IsNullOrEmpty(Password))
				builder.Password = Password;

			this.connectionString = builder.ToString();
		}

		/// <summary>
		/// Create the SQL server connections.
		/// </summary>
		/// <exception cref="ArgumentException"></exception>
		public void InitializeConnection()
		{
			GenerateConnectionString();

			sqlConnection = new SqlConnection(this.connectionString);
			server = new Server(new ServerConnection(sqlConnection));

			connected = true;
		}

		/// <summary>
		/// Execute a non-query SQL command.
		/// </summary>
		/// <param name="command">The SQL command to execute.</param>
		public int ExecuteNonQuery(string command)
		{
			return server.ConnectionContext.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Execute a non-query SQL command from a SQL script file.
		/// </summary>
		/// <param name="scriptPath">The path to the SQL script.</param>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="PathTooLongException"></exception>
		/// <exception cref="DirectoryNotFoundException"></exception>
		/// <exception cref="IOException"></exception>
		/// <exception cref="UnauthorizedAccessException"></exception>
		/// <exception cref="FileNotFoundException"></exception>
		/// <exception cref="NotSupportedException"></exception>
		/// <exception cref="System.Security.SecurityException"></exception>
		public void ExecuteScriptNonQuery(string scriptPath)
		{
			if (!File.Exists(scriptPath))
				throw new FileNotFoundException($"The provided script path is not a valid path.");

			string scriptContent = File.ReadAllText(scriptPath);

			ExecuteNonQuery(scriptContent);
		}

		/// <summary>
		/// Execute a SQL query.
		/// </summary>
		/// <param name="query">The SQL query to execute.</param>
		/// <returns>IDataRecord[] containing the returned records.</returns>
		/// <exception cref="SqlException"></exception>
		public IDataRecord[] ExecuteQuery(string query)
		{
			List<IDataRecord> records = new List<IDataRecord>();

			using (var dataReader = server.ConnectionContext.ExecuteReader(query))
			{
				while (dataReader.Read())
				{
					records.Add((IDataRecord)dataReader);
				}
			}

			return records.ToArray();
		}

		/// <summary>
		/// Execute a SQL query from a SQL script file.
		/// </summary>
		/// <param name="scriptPath"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="PathTooLongException"></exception>
		/// <exception cref="DirectoryNotFoundException"></exception>
		/// <exception cref="IOException"></exception>
		/// <exception cref="UnauthorizedAccessException"></exception>
		/// <exception cref="FileNotFoundException"></exception>
		/// <exception cref="NotSupportedException"></exception>
		/// <exception cref="System.Security.SecurityException"></exception>
		public IDataRecord[] ExecuteScriptQuery(string scriptPath)
		{
			if (!File.Exists(scriptPath))
				throw new FileNotFoundException($"The provided script path is not a valid path.");

			var query = File.ReadAllText(scriptPath);

			List<IDataRecord> records = new List<IDataRecord>();

			using (var dataReader = server.ConnectionContext.ExecuteReader(query))
			{
				while (dataReader.Read())
				{
					records.Add((IDataRecord)dataReader);
				}
			}

			return records.ToArray();
		}
	}
}