using System;
using NAnt.Core;
using NAntUtilities;

namespace NAntSqlHandler {
	[TaskName("sql.execute.nonquery.script")]
	public class ExecuteNonQueryScript : NAnt.Core.Task {
		/// <summary>
		/// The SQL server to connect to.
		/// </summary>
		[TaskAttribute("server", Required = true)]
		public string Server { get; set; }

		/// <summary>
		/// The the path to the SQL non-query script.
		/// </summary>
		[TaskAttribute("sqlScript", Required = true)]
		public string SqlScript { get; set; }

		/// <summary>
		/// The inital catalog to connect to.
		/// </summary>
		[TaskAttribute("initialCatalog", Required = false)]
		public string InitialCatalog { get; set; }

		/// <summary>
		/// The user to use to connect to the server when using SQL authentication.
		/// </summary>
		[TaskAttribute("userID", Required = false)]
		public string UserID { get; set; }

		/// <summary>
		/// The password to use to connect to the server when using SQL authentication.
		/// </summary>
		[TaskAttribute("password", Required = false)]
		public string Password { get; set; }

		/// <summary>
		/// Enables/disables IntegratedSecurity in the connection string.
		/// </summary>
		[TaskAttribute("integratedSecurity", Required = false)]
		public bool IntegratedSecurity { get; set; } = true;

		/// <summary>
		/// Enables/disables Pooling in the connection string.
		/// </summary>
		[TaskAttribute("pooling", Required = false)]
		public bool Pooling { get; set; } = false;

		/// <summary>
		/// TrustServerCertificate bypasses the SQL server certificate check.
		/// </summary>
		[TaskAttribute("trustServerCertificate", Required = false)]
		public bool TrustServerCertificate { get; set; } = false;

		/// <summary>
		/// Forces the build to fail on error.
		/// </summary>
		[TaskAttribute("failOnError", Required = false)]
		public bool FailOnError { get; get; } = true;

		protected override void ExecuteTask()
		{
			using (var sql = new Sql()) {
				sql.Server = Server;
				sql.InitialCatalog = InitialCatalog;
				sql.UserID = UserID;
				sql.Password = Password;
				sql.Connected = Connected;
				sql.IntegratedSecurity = IntegratedSecurity;
				sql.Pooling = Pooling;
				sql.TrustServerCertificate = TrustServerCertificate;

				try {
					sql.InitializeConnection();
					sql.ExecuteScriptNonQuery(SqlScript);
				}
				catch(Exception ex) {
					logError(ex);
				}
			}
		}

		private void logError(Exception ex) {
			Project.Log(Level.Error, ex.Message);

			if (FailOnError)
				throw new BuildException(ex.Message, ex);
		}
	}
}