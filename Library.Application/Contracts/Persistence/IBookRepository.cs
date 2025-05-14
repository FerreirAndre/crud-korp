using Library.Domain;

namespace Library.Application.Contracts.Persistence;

public interface IBookRepository
{
    Task CreateAsync(Book entity);
    Task<Book> GetByIdAsync(int id);
    Task<IReadOnlyList<Book>> GetAsync();
    Task UpdateAsync(Book entity);
    Task DeleteAsync(Book entity);
    Task<bool> IsBookTitleUnique(string title);
}