<a name='assembly'></a>
# NAntUtilities

## Contents

- [Sql](#T-NAntUtilities-Sql 'NAntUtilities.Sql')
  - [connected](#F-NAntUtilities-Sql-connected 'NAntUtilities.Sql.connected')
  - [connectionString](#F-NAntUtilities-Sql-connectionString 'NAntUtilities.Sql.connectionString')
  - [disposed](#F-NAntUtilities-Sql-disposed 'NAntUtilities.Sql.disposed')
  - [server](#F-NAntUtilities-Sql-server 'NAntUtilities.Sql.server')
  - [sqlConnection](#F-NAntUtilities-Sql-sqlConnection 'NAntUtilities.Sql.sqlConnection')
  - [Connected](#P-NAntUtilities-Sql-Connected 'NAntUtilities.Sql.Connected')
  - [InitialCatalog](#P-NAntUtilities-Sql-InitialCatalog 'NAntUtilities.Sql.InitialCatalog')
  - [IntegratedSecurity](#P-NAntUtilities-Sql-IntegratedSecurity 'NAntUtilities.Sql.IntegratedSecurity')
  - [Password](#P-NAntUtilities-Sql-Password 'NAntUtilities.Sql.Password')
  - [Pooling](#P-NAntUtilities-Sql-Pooling 'NAntUtilities.Sql.Pooling')
  - [Server](#P-NAntUtilities-Sql-Server 'NAntUtilities.Sql.Server')
  - [TrustServerCertificate](#P-NAntUtilities-Sql-TrustServerCertificate 'NAntUtilities.Sql.TrustServerCertificate')
  - [UserID](#P-NAntUtilities-Sql-UserID 'NAntUtilities.Sql.UserID')
  - [Dispose()](#M-NAntUtilities-Sql-Dispose 'NAntUtilities.Sql.Dispose')
  - [Dispose()](#M-NAntUtilities-Sql-Dispose-System-Boolean- 'NAntUtilities.Sql.Dispose(System.Boolean)')
  - [ExecuteNonQuery(command)](#M-NAntUtilities-Sql-ExecuteNonQuery-System-String- 'NAntUtilities.Sql.ExecuteNonQuery(System.String)')
  - [ExecuteQuery(query)](#M-NAntUtilities-Sql-ExecuteQuery-System-String- 'NAntUtilities.Sql.ExecuteQuery(System.String)')
  - [ExecuteScriptNonQuery(scriptPath)](#M-NAntUtilities-Sql-ExecuteScriptNonQuery-System-String- 'NAntUtilities.Sql.ExecuteScriptNonQuery(System.String)')
  - [ExecuteScriptQuery(scriptPath)](#M-NAntUtilities-Sql-ExecuteScriptQuery-System-String- 'NAntUtilities.Sql.ExecuteScriptQuery(System.String)')
  - [Finalize()](#M-NAntUtilities-Sql-Finalize 'NAntUtilities.Sql.Finalize')
  - [GenerateConnectionString()](#M-NAntUtilities-Sql-GenerateConnectionString 'NAntUtilities.Sql.GenerateConnectionString')
  - [InitializeConnection()](#M-NAntUtilities-Sql-InitializeConnection 'NAntUtilities.Sql.InitializeConnection')

<a name='T-NAntUtilities-Sql'></a>
## Sql `type`

##### Namespace

NAntUtilities

##### Summary

This class provides methods for executing SQL commands and queries.

##### Example

```
using (var sql = new NAntUtilities.Sql()) {
    sql.Server = "localhost";
    sql.InitializeConnection();
    sql.ExecuteNonQuery("INSERT INTO ...");
}
```

##### Remarks

Implements [IDisposable](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IDisposable 'System.IDisposable')

<a name='F-NAntUtilities-Sql-connected'></a>
### connected `constants`

##### Summary

The connection state of the sql connection and server connection.

<a name='F-NAntUtilities-Sql-connectionString'></a>
### connectionString `constants`

##### Summary

The generated connection string based on the class parameters.

<a name='F-NAntUtilities-Sql-disposed'></a>
### disposed `constants`

##### Summary

Has been disposed.

<a name='F-NAntUtilities-Sql-server'></a>
### server `constants`

##### Summary

The server connection object.

<a name='F-NAntUtilities-Sql-sqlConnection'></a>
### sqlConnection `constants`

##### Summary

The sql connection object.

<a name='P-NAntUtilities-Sql-Connected'></a>
### Connected `property`

##### Summary

The connection state of the sql connection and server connection.

<a name='P-NAntUtilities-Sql-InitialCatalog'></a>
### InitialCatalog `property`

##### Summary

The inital catalog to connect to.

<a name='P-NAntUtilities-Sql-IntegratedSecurity'></a>
### IntegratedSecurity `property`

##### Summary

Enables/disables IntegratedSecurity in the connection string.

<a name='P-NAntUtilities-Sql-Password'></a>
### Password `property`

##### Summary

The password to use to connect to the server when using SQL authentication.

<a name='P-NAntUtilities-Sql-Pooling'></a>
### Pooling `property`

##### Summary

Enables/disables Pooling in the connection string.

<a name='P-NAntUtilities-Sql-Server'></a>
### Server `property`

##### Summary

The SQL server to connect to.

<a name='P-NAntUtilities-Sql-TrustServerCertificate'></a>
### TrustServerCertificate `property`

##### Summary

TrustServerCertificate bypasses the SQL server certificate check.

<a name='P-NAntUtilities-Sql-UserID'></a>
### UserID `property`

##### Summary

The user to use to connect to the server when using SQL authentication.

<a name='M-NAntUtilities-Sql-Dispose'></a>
### Dispose() `method`

##### Summary

Dispose all managed resources.

##### Parameters

This method has no parameters.

<a name='M-NAntUtilities-Sql-Dispose-System-Boolean-'></a>
### Dispose() `method`

##### Summary

Dispose all managed resources.

##### Parameters

This method has no parameters.

<a name='M-NAntUtilities-Sql-ExecuteNonQuery-System-String-'></a>
### ExecuteNonQuery(command) `method`

##### Summary

Execute a non-query SQL command.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| command | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The SQL command to execute. |

<a name='M-NAntUtilities-Sql-ExecuteQuery-System-String-'></a>
### ExecuteQuery(query) `method`

##### Summary

Execute a SQL query.

##### Returns

IDataRecord[] containing the returned records.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The SQL query to execute. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [Microsoft.Data.SqlClient.SqlException](#T-Microsoft-Data-SqlClient-SqlException 'Microsoft.Data.SqlClient.SqlException') |  |

<a name='M-NAntUtilities-Sql-ExecuteScriptNonQuery-System-String-'></a>
### ExecuteScriptNonQuery(scriptPath) `method`

##### Summary

Execute a non-query SQL command from a SQL script file.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| scriptPath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The path to the SQL script. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') |  |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') |  |
| [System.IO.PathTooLongException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.PathTooLongException 'System.IO.PathTooLongException') |  |
| [System.IO.DirectoryNotFoundException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.DirectoryNotFoundException 'System.IO.DirectoryNotFoundException') |  |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') |  |
| [System.UnauthorizedAccessException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UnauthorizedAccessException 'System.UnauthorizedAccessException') |  |
| [System.IO.FileNotFoundException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.FileNotFoundException 'System.IO.FileNotFoundException') |  |
| [System.NotSupportedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotSupportedException 'System.NotSupportedException') |  |
| [System.Security.SecurityException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Security.SecurityException 'System.Security.SecurityException') |  |

<a name='M-NAntUtilities-Sql-ExecuteScriptQuery-System-String-'></a>
### ExecuteScriptQuery(scriptPath) `method`

##### Summary

Execute a SQL query from a SQL script file.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| scriptPath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') |  |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') |  |
| [System.IO.PathTooLongException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.PathTooLongException 'System.IO.PathTooLongException') |  |
| [System.IO.DirectoryNotFoundException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.DirectoryNotFoundException 'System.IO.DirectoryNotFoundException') |  |
| [System.IO.IOException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.IOException 'System.IO.IOException') |  |
| [System.UnauthorizedAccessException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.UnauthorizedAccessException 'System.UnauthorizedAccessException') |  |
| [System.IO.FileNotFoundException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.FileNotFoundException 'System.IO.FileNotFoundException') |  |
| [System.NotSupportedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotSupportedException 'System.NotSupportedException') |  |
| [System.Security.SecurityException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Security.SecurityException 'System.Security.SecurityException') |  |

<a name='M-NAntUtilities-Sql-Finalize'></a>
### Finalize() `method`

##### Summary

Call dispose without disposing properly.

##### Parameters

This method has no parameters.

<a name='M-NAntUtilities-Sql-GenerateConnectionString'></a>
### GenerateConnectionString() `method`

##### Summary

Generate a SQL connection string based on the class parameters.

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') |  |

<a name='M-NAntUtilities-Sql-InitializeConnection'></a>
### InitializeConnection() `method`

##### Summary

Create the SQL server connections.

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') |  |
