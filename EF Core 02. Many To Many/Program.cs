
using BookContext db = new(); 

Book book = new Book()
{
    Name = "UydaaaChtoEto",
    Pages = 256,
    Authors = new List<Author>()
    {
        new Author()
        {
            FirstName = "Kto To",
            LastName = "KtoToyev"
        },
        new Author()
        {
            FirstName = "Uydaa",
            LastName = "Aydayev"
        }
    }
};

db.Books.Add(book);
db.SaveChanges();

