using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory());
builder.AddJsonFile("appsettings.json");

var config = builder.Build();
var connectionString = config.GetConnectionString("MyConnectionString");
#region Sql Injection
// Sql Injection

//using (SqlConnection connection = new(connectionString))
//{
//    string id = Console.ReadLine();
//    connection.Open();
//    SqlCommand command = new(@$"
//SELECT * 
//FROM Authors
//WHERE Id = {id}
//", connection);

//    SqlDataReader reader = command.ExecuteReader();
//    do
//    {
//        while (reader.Read())
//        {
//            for (int i = 0; i < reader.FieldCount; i++)
//            {
//                Console.Write($"{reader[i]} ");
//            }
//            Console.WriteLine();
//        }
//        Console.WriteLine();

//    } while (reader.NextResult());
//}
#endregion

#region Parametrized query

using (SqlConnection connection = new(connectionString))
{
    string id = Console.ReadLine();
    connection.Open();
    SqlCommand command = new(@"
SELECT * 
FROM Authors
WHERE Id > @id AND FirstName LIKE @firstname
", connection);

    //SqlParameter parameter = new();
    //parameter.ParameterName = "@id";
    //parameter.SqlDbType = System.Data.SqlDbType.Int;
    //parameter.Value = id;

    //command.Parameters.Add(parameter);

    command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
    command.Parameters
        .Add("@firstname", System.Data.SqlDbType.NVarChar)
        .Value = Console.ReadLine();

    SqlDataReader reader = command.ExecuteReader();
    do
    {
        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($"{reader[i]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

    } while (reader.NextResult());
}
#endregion

