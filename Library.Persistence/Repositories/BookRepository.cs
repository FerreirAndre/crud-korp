using Library.Application.Contracts.Persistence;
using Library.Domain;
using Library.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Repositories;

public class BookRepository(LibraryDatabaseContext context) : IBookRepository
{
    public async Task CreateAsync(Book entity)
    {
        await context.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task<Book> GetByIdAsync(int id)
    {
        return await context.Set<Book>().AsNoTracking().FirstOrDefaultAsync(x=> x.Id == id);
    }

    public async Task<IReadOnlyList<Book>> GetAsync()
    {
        return await context.Set<Book>().AsNoTracking().ToListAsync();
    }

    public async Task UpdateAsync(Book entity)
    {
        var existingBook = await context.Books.FindAsync(entity.Id);

        if (existingBook == null)
            throw new InvalidOperationException($"Book with Id {entity.Id} not found");

        existingBook.Title = entity.Title;
        existingBook.Author = entity.Author;
        existingBook.Summary = entity.Summary;

        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Book entity)
    {
        context.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task<bool> IsBookTitleUnique(string title)
    {
        return await context.Books.AnyAsync(x => x.Title == title) == false;
    }
}