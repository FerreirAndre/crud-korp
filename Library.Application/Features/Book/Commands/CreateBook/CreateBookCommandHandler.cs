using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.Exceptions;
using MediatR;

namespace Library.Application.Features.Book.Commands.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateBookCommandValidator(_bookRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Book", validationResult);
        
        var bookToCreate = _mapper.Map<Domain.Book>(request);
        
        await _bookRepository.CreateAsync(bookToCreate);
        
        return bookToCreate.Id;
    }
}