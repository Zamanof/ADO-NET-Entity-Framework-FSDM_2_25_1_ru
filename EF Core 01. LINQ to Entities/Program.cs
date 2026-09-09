// LINQ To Entities
using EF_Core_01._LINQ_to_Entities;
using Microsoft.EntityFrameworkCore;

using LibraryContext db = new();

//var authors = (from author in db.Authors
//               where author.Id > 5
//               select author).ToList();

//authors.ForEach(Console.WriteLine);

#region Where
//db.Authors
//    .Where(a => a.Id > 5)
//    .ToList()
//    .ForEach(Console.WriteLine);

//db.Authors
//    .Where(a => a.Id > 5 && a.FirstName != "Mark")
//    .ToList()
//    .ForEach(Console.WriteLine);

#endregion

#region EF.Functions.Like
//db.Authors
//    .Where(a => a.FirstName.StartsWith("M"))
//    .ToList()
//    .ForEach(Console.WriteLine);

//db.Authors
//    .ToList()
//    .Where(a => a.FirstName[0] == 'M')
//    .ToList()
//    .ForEach(Console.WriteLine);

//db.Authors
//    .ToList()
//    .Where(a => a.FirstName[1..3] == "ar")
//    .ToList()
//    .ForEach(Console.WriteLine);

//db.Authors
//    .Where(a => EF.Functions.Like(a.FirstName, "_ar%"))
//    .ToList()
//    .ForEach(Console.WriteLine);

//db.Authors
//    .Where(a => EF.Functions.Like(a.LastName, "[^AMD]%"))
//    .ToList()
//    .ForEach(Console.WriteLine);

db.Authors
    .Where(a => EF.Functions.Like(a.LastName, "[A-F]%"))
    .ToList()
    .ForEach(Console.WriteLine);


#endregion