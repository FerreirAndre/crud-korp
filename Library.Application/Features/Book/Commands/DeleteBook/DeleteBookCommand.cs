using MediatR;

namespace Library.Application.Features.Book.Commands.DeleteBook;

public record DeleteBookCommand(int Id):IRequest<Unit>;