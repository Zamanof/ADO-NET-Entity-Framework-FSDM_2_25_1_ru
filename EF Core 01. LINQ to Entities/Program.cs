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

//db.Authors
//    .Where(a => EF.Functions.Like(a.LastName, "[A-F]%"))
//    .ToList()
//    .ForEach(Console.WriteLine);


#endregion

#region First, FirstOrDefault, Single, SingleOrDefault, Find

//var author = db.Authors.FirstOrDefault(a => a.FirstName == "Marka");
//if (author is not null) Console.WriteLine(author);
//else Console.WriteLine("Author not found");


//var author1 = db.Authors.SingleOrDefault(a => a.FirstName == "Mar");
//if (author1 is not null) Console.WriteLine(author1);
//else Console.WriteLine("Author not found");

//var author2 = db.Authors.Find(15);
//if (author2 is not null) Console.WriteLine(author2);
//else Console.WriteLine("Author not found");

#endregion

#region All, Any
//Console.WriteLine(db.Authors.All(a => a.FirstName.Length > 3));
//Console.WriteLine(db.Authors.Any(a => a.FirstName == "Olga"));
#endregion

#region Select
//var authors = db.Authors.Select(a => a.FirstName + " " + a.LastName).ToList();
/*
SELECT FirstName + " " + LastName
FROM Authors
*/

//authors.ForEach(Console.WriteLine);

//var authors1 = db.Authors.Select(a => new
//{
//    Id = a.Id,
//    FullName = $"{a.FirstName} {a.LastName}",
//    Books = a.Books
//}).ToList();

//foreach (var author in authors1)
//{
//    Console.WriteLine($"{author.Id} {author.FullName}");

//    foreach (var book in author.Books)
//    {
//        Console.WriteLine($"\t{book.Name}");
//    }
//}

#endregion

#region OrderBy, OrderByDescending, ThenBy, ThenByDescending
//var authors = db.Authors
//                        .OrderBy(a => a.FirstName)
//                        .ThenByDescending(a => a.LastName)
//                        .ToList();

//authors.ForEach(Console.WriteLine);
/*
SELECT *
FROM Authors
ORDER BY FirstName, LastName DESC 
*/
#endregion

#region Skip, SkipWhile, Take, TakeWhile
//var authors = db.Authors
//                        .OrderBy(a => a.FirstName)
//                        .Skip(2)
//                        .Take(4);

/*
SELECT *
FROM Authors
ORDER BY FirstName
OFFSET (2) ROWS
FETCH NEXT (4) ROWS ONLY
*/

//authors.ForEach(Console.WriteLine);
#endregion

#region Join
//var books = db.Books.Join(db.Authors, b => b.IdAuthor, a => a.Id,
//    (b, a) => new
//    {
//        Name = b.Name,
//        Author = $"{a.FirstName} {a.LastName}"
//    }).ToList();

//books.ForEach(b => Console.WriteLine($"Book Name: {b.Name}\nAuthor: {b.Author}\n"));

/*
SELECT B.Name, A.FirstName + ' ' + A.LastName AS Author
FROM Books AS B
JOIN Authors AS A
ON B.Id_Author = A.Id
*/

#endregion

#region LINQ to Entities
/*
https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/ef/language-reference/linq-to-entities
https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/ef/language-reference/method-based-query-syntax-examples-projection

LINQ to Entities Methods
        All
        Any
        Average
        Contains
        Count
        First
        FirstOrDefault
        Single
        SingleOrDefault
        Select
        Where
        OrderBy
        OrderByDescending
        ThenBy
        ThenByDescending
        Join
        LeftJoin
        GroupBy
        Except
        Union
        Intersect
        Sum
        Max
        Min
        Take
        TakeWhile
        Skip
        SkipWhile
        ToList
*/
#endregion
