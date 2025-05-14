using Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.DatabaseContext;

public class LibraryDatabaseContext : DbContext
{
    public LibraryDatabaseContext(DbContextOptions<LibraryDatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryDatabaseContext).Assembly);
        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = 1,
                Title = "A República",
                Author = "Platão",
                Summary =
                    "A República é um diálogo socrático escrito por Platão, " +
                    "filósofo grego, no século IV a.C. Todo o diálogo é narrado, " +
                    "em primeira pessoa, por Sócrates."
            }
        );
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Book> Books { get; set; }
}