using Microsoft.Data.SqlClient;

string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=AdoTest;Integrated Security=True;Trust Server Certificate=True;";

SqlDataReader reader = null;
SqlCommand cmd = null;

#region Read Data

//using (var connection = new SqlConnection(connectionString))
//{
//    cmd = new SqlCommand(@"SELECT * FROM Authors", connection);

//    connection.Open();

//    reader = cmd.ExecuteReader();

//    while (reader.Read())
//    {
//        Console.WriteLine($"{reader[0]}. {reader[1]} {reader[2]}");
//    }
//}
#endregion


#region Read Data Indexer
//using (var connection = new SqlConnection(connectionString))
//{
//    cmd = new SqlCommand(@"SELECT * FROM Authors", connection);

//    connection.Open();

//    reader = cmd.ExecuteReader();

//    while (reader.Read())
//    {
//        Console.WriteLine($"{reader["Id"]}. {reader["FirstName"]} {reader["LastName"]}");
//    }
//}
#endregion

#region FieldCount, .GetName()
//using (var connection = new SqlConnection(connectionString))
//{
//    cmd = new SqlCommand(@"SELECT * FROM Authors", connection);

//    connection.Open();

//    reader = cmd.ExecuteReader();
//Console.WriteLine(reader.FieldCount);
//Console.WriteLine(reader.GetName(0));
//Console.WriteLine(reader.GetName(1));
//Console.WriteLine(reader.GetName(2));

//    bool line = true;

//    while (reader.Read())
//    {
//        if (line)
//        {
//            for (int i = 0; i < reader.FieldCount; i++)
//            {
//                Console.Write($"{reader.GetName(i)}\t\t\t");
//            }
//            Console.WriteLine();
//            line = false;

//        }
//        for (int i = 0; i < reader.FieldCount; i++)
//        {
//            Console.Write($"{reader[i]}\t\t\t");
//        }
//        Console.WriteLine();

//    }
//}
#endregion

