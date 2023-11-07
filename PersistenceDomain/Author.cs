using System.ComponentModel.DataAnnotations.Schema;

namespace PersistenceDomain;

[Table("authors")]
public class Author
{
    public Author()
    {
        Books = new List<Book>();
    }

    [Column("id")]
    public int Id { get; set; }

    [Column("first_name")]
    public string FirstName { get; set; }

    [Column("last_name")]
    public string LastName { get; set; }

    public List<Book> Books { get; set; }
}
