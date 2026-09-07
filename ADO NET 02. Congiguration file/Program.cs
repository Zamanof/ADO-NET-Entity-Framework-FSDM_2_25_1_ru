// Configuration file

// connection string in code file (hard code) - not secure
//string connectionString = @"
//Server=(localdb)\MSSQLLocalDB;
//Database=Library;
//Integrated Security=True;
//Trust Server Certificate=True;";

using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory());
builder.AddJsonFile("appsettings.json");

var config = builder.Build();
var connectionString = config.GetConnectionString("MyConnectionString");

List<Author> authors = new();

using (SqlConnection con = new SqlConnection(connectionString))
{
    con.Open();
    SqlCommand command = new("SELECT * FROM Authors;", con);

    SqlDataReader reader = command.ExecuteReader();

    while (reader.Read())
    {
        authors.Add(new Author
        {
            Id = (int)reader[0],
            FirstName = reader[1].ToString(),
            LastName = reader[2].ToString()
        });
    }
}

authors.ForEach(Console.WriteLine);