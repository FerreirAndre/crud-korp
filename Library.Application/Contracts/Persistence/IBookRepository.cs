using Library.Domain;

namespace Library.Application.Contracts.Persistence;

public interface IBookRepository
{
    Task<Book> CreateAsync(Book entity);
    Task<Book> GetByIdAsync(int id);
    Task<List<Book>> GetAsync();
    Task<Book> UpdateAsync(Book entity);
    Task<Book> DeleteAsync(Book entity);
    Task<bool> IsBookTitleUnique(string title);
}