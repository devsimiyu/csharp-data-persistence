using Microsoft.EntityFrameworkCore;
using PersistenceDomain;

namespace PersistenceData;

public class PersistenceContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=csharp_data_persistence;Username=postgres;Password=password");
    }
}
