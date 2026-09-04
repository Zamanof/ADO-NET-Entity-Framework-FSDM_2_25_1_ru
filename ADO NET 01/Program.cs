#region ADO Overview
/*
ADO .NET - ActiveX Data Object for .NET
https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/ado-net-overview
https://en.wikipedia.org/wiki/ADO.NET

MSSQL Server, Oracle, OLE DB, ODBC, ...

ADO Classes:
    - DbConnection(SqlConnection, ...)
    - DbCommand
    - DbDataReader
    - DbDataAdapter
    - ...

ADO Datatype for DB
    - DataTable
    - DataSet
    - ...

Connection modes:
    - Connected Mode
    - Disconnected Mode

- DB First
- Code First
- Model First 
*/
#endregion

#region Connection String
// https://www.connectionstrings.com/
// SQL Server Authentication
// Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;
// Data Source=myServerAddress;Initial Catalog=myDataBase;User Id=myUsername;Password=myPassword;

// Windows Authentication
// Server=myServerAddress;Database=myDataBase;Integrated Security=true;
// Data Source=myServerAddress;Initial Catalog=myDataBase;Integrated Security=SSPI;

// Data Source=STHQ0124-01;User ID=admin;Password=********;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;
#endregion

using Microsoft.Data.SqlClient;

SqlConnection connection = default;

string connectionString = @"Server=STHQ0124-01;
                            Database=AdoTest;
                            User ID=admin;
                            Password=admin;
                            Trust Server Certificate=True;";

#region DatabaseConnection
//connection = new SqlConnection(connectionString);

//string insertQuery = """
//    INSERT INTO Authors (FirstName, LastName)
//    VALUES('Aleksandr', 'Pushkin')
//    """;

////SqlCommand command = new(insertQuery, connection);

//SqlCommand command = new();
//command.Connection = connection;
//command.CommandText = insertQuery;

//try
//{
//    connection.Open();
//    command.ExecuteNonQuery();
//}
//finally
//{
//    if (connection is not null) connection.Close();
//}



#endregion

#region DatabaseConnection with using
//using (connection = new(connectionString))
//{
//    connection.Open();
//    string FirstName = Console.ReadLine();
//    string LastName = Console.ReadLine();
//    string insertQuery = $"""
//    INSERT INTO Authors (FirstName, LastName)
//    VALUES('{FirstName}', '{LastName}')
//    """;
//    SqlCommand command = new(insertQuery, connection);

//    command.ExecuteNonQuery();
//}
#endregion

