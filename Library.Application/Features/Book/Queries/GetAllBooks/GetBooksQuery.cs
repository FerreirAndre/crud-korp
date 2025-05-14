using MediatR;

namespace Library.Application.Features.Book.Queries.GetAllBooks;

public record GetBooksQuery : IRequest<List<BookDto>>;