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

        modelBuilder.Entity<Domain.Book>().HasData(
            new Domain.Book
            {
                Id = 1,
                Title = "A República",
                Author = "Platão",
                Summary =
                    "A República é um diálogo socrático escrito por Platão, " +
                    "filósofo grego, no século IV a.C. Todo o diálogo é narrado, " +
                    "em primeira pessoa, por Sócrates."
            },
            new Domain.Book
            {
                Id = 2,
                Title = "A Metamorfose",
                Author = "Franz Kafka",
                Summary = "A Metamorfose narra a história de Gregor Samsa, um caixeiro-viajante que acorda " +
                          "transformado em um inseto monstruoso"
            }
        );
    }

    public DbSet<Domain.Book> Books { get; set; }
}