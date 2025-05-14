using Library.Application.Contracts.Persistence;
using Library.Application.Exceptions;
using MediatR;

namespace Library.Application.Features.Book.Commands.DeleteBook;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
{
    private readonly IBookRepository _bookRepository;

    public DeleteBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var bookToDelete = await _bookRepository.GetByIdAsync(request.Id);
        if (bookToDelete == null)
            throw new NotFoundException(nameof(Book), request.Id);
        
        await _bookRepository.DeleteAsync(bookToDelete);
        
        return Unit.Value;
    }
}