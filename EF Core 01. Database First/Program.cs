// Database First
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

Console.WriteLine();
var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory());
builder.AddJsonFile("appsettings.json");
var config = builder.Build();
var connectionString = config.GetConnectionString("MyConnectionString");


using LibraryContext db = new(connectionString!);
var libs = db.Libs.ToList();
var authors = db.Authors.ToList();

authors.ForEach(Console.WriteLine);
Console.WriteLine();
libs.ForEach(Console.WriteLine);