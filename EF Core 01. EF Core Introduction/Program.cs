// EF Core - Entity Framework Core
// ORM - Object-Relational Mapper

// Database First
// Code First

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

Console.WriteLine();
var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory());
builder.AddJsonFile("appsettings.json");
var config = builder.Build();
var connectionString = config.GetConnectionString("MyConnectionString");

#region Add Data

//using (StudentContext db = new StudentContext(connectionString!))
//{
//    Student student = new()
//    {
//        FirstName = "Nadir",
//        LastName = "Zamanov",
//        Age = 46,
//        Gender = "male",
//        Group = "A13"
//    };
//    db.Students.Add(student);
//    db.SaveChanges();
//}

#endregion

#region Add Datas
//List<Student> students =
//[
//    new()
//    {
//        FirstName = "Peter",
//        LastName = "Parker",
//        Age = 21,
//        Gender = "male",
//        Group = "A13"
//    },
//    new()
//    {
//        FirstName = "Gwen",
//        LastName = "Stacy",
//        Age = 20,
//        Gender = "female",
//        Group = "A13"
//    },
//    new()
//    {
//        FirstName = "Miles",
//        LastName = "Morales",
//        Age = 18,
//        Gender = "male",
//        Group = "A14"
//    },
//    new()
//    {
//        FirstName = "Mary Jane",
//        LastName = "Watson",
//        Age = 21,
//        Gender = "female",
//        Group = "A13"
//    },
//    new()
//    {
//        FirstName = "Harry",
//        LastName = "Osborn",
//        Age = 22,
//        Gender = "male",
//        Group = "A14"
//    },
//    new()
//    {
//        FirstName = "Felicia",
//        LastName = "Hardy",
//        Age = 23,
//        Gender = "female",
//        Group = "A15"
//    },
//    new()
//    {
//        FirstName = "Eddie",
//        LastName = "Brock",
//        Age = 24,
//        Gender = "male",
//        Group = "A15"
//    },
//    new()
//    {
//        FirstName = "Flash",
//        LastName = "Thompson",
//        Age = 21,
//        Gender = "male",
//        Group = "A14"
//    },
//    new()
//    {
//        FirstName = "Cindy",
//        LastName = "Moon",
//        Age = 20,
//        Gender = "female",
//        Group = "A13"
//    },
//    new()
//    {
//        FirstName = "Betty",
//        LastName = "Brant",
//        Age = 22,
//        Gender = "female",
//        Group = "A15"
//    }
//];

//using (StudentContext db = new StudentContext(connectionString!))
//{
//    //foreach (var student in students)
//    //{
//    //    db.Students.Add(student);
//    //}
//    db.Students.AddRange(students);
//    db.SaveChanges();
//}
#endregion

#region Read Data
//using (StudentContext db = new StudentContext(connectionString!))
//{
//    int.TryParse(Console.ReadLine(), out int id);
//    var student = db.Students.FirstOrDefault(s => s.Id == id);

//    //var student = db.Students.FirstOrDefault(s => s.FirstName == "Peter");

//    if (student is not null) Console.WriteLine(student);
//    else Console.WriteLine("Student not found");
//}
#endregion

#region Read Datas
//using (StudentContext db = new StudentContext(connectionString!))
//{

//    //List<Student> students = new();
//    ////foreach (var student in db.Students)
//    ////{
//    ////    students.Add(student);
//    ////}

//    var students = db.Students.ToList();

//    foreach (var student in students)
//    {
//        Console.WriteLine(student);
//    }    
//}
#endregion

#region Update Data
//using StudentContext db = new StudentContext(connectionString!);
//var student = db.Students.FirstOrDefault(s => s.Id == 26);
//if (student is not null)
//{
//    student.LastName = "Zaman";
//    student.Age = 45;
//}
//db.Students.Update(student!);
//db.SaveChanges();

#endregion


#region Delete datas
//using StudentContext db = new StudentContext(connectionString!);
//db.Students.Remove(db.Students.First());

//var deletedStudents = db.Students.Where(s => s.FirstName == "Olqa");

//db.RemoveRange(deletedStudents);

//db.SaveChanges();
#endregion