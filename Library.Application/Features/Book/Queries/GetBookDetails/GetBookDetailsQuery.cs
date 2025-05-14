using MediatR;

namespace Library.Application.Features.Book.Queries.GetBookDetails;

public record GetBookDetailsQuery(int id) : IRequest<BookDetailsDto>;