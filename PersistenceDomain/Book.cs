using System.ComponentModel.DataAnnotations.Schema;

namespace PersistenceDomain;

[Table("books")]
public class Book
{
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    public string Title { get; set; }

    [Column("publish_date")]
    public DateTime PublishDate { get; set; }

    [Column("base_price")]
    public decimal BasePrice { get; set; }

    [Column("author_id")]
    public int AuthorId { get; set; }

    public Author Author { get; set; }
}
