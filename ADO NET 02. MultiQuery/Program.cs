using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory());
builder.AddJsonFile("appsettings.json");

var config = builder.Build();
var connectionString = config.GetConnectionString("MyConnectionString");

using (SqlConnection connection = new(connectionString))
{
    connection.Open();
    SqlCommand command = new(@"
SELECT * 
FROM Authors;

SELECT Id, Name, Pages
FROM Books;
", connection);

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
