using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.Exceptions;
using MediatR;

namespace Library.Application.Features.Book.Commands.UpdateBook;

public class UpdateBookCommandHandler:IRequestHandler<UpdateBookCommand,Unit>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public UpdateBookCommandHandler(IBookRepository bookRepository,IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateBookCommandValidator(_bookRepository);
        var validationResult = await validator.ValidateAsync(request);
        
        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Book", validationResult);
        
        var bookToUpdate = _mapper.Map<Domain.Book>(request);
        await _bookRepository.UpdateAsync(bookToUpdate);
        
        return Unit.Value;
    }
}