// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using PersistenceData;
using PersistenceDomain;

using (PersistenceContext dbContext = new PersistenceContext())
{
    dbContext.Database.EnsureCreated();
}

AddAuthor();

void AddAuthor()
{
    using var dbContext = new PersistenceContext();
    var author = new Author { FirstName = "Joe", LastName = "Mfalme" };
    dbContext.Authors.Add(author);
    dbContext.SaveChanges();
    Console.WriteLine($"Author added: {author.Id}");
}

GetAuthors();

void GetAuthors()
{
    using var dbContext = new PersistenceContext();
    var authorList = dbContext.Authors.ToList();
    if (authorList.Any()) authorList.ForEach(author => Console.WriteLine($"Author loaded: {author.FirstName} {author.LastName}"));
    else Console.WriteLine("No authors");
}

AddAuthorBooks();

void AddAuthorBooks()
{
    using var dbContext = new PersistenceContext();
    var authorList = dbContext.Authors.ToList();
    var random = new Random();
    foreach (var (author, index) in authorList.Select((value, index) => (value, index)))
    {
        var book = new Book { 
            Title = "title #" + index, 
            PublishDate = DateTime.SpecifyKind(new DateTime(2021, 9, 21), DateTimeKind.Utc), 
            BasePrice = random.Next(50, 1000) 
        };
        author.Books.Add(book);
    }
    dbContext.SaveChanges();
}

GetAuthorBooks();

void GetAuthorBooks()
{
    using var dbContext = new PersistenceContext();
    var authorList = dbContext.Authors.Include(author => author.Books).ToList();
    foreach (var author in authorList)
    {
        if (author.Books.Any()) author.Books.ForEach(book => Console.WriteLine($"Book loaded: {book.Title}"));
        else Console.WriteLine($"No books for author: {author.FirstName} {author.LastName}");
    }
}
