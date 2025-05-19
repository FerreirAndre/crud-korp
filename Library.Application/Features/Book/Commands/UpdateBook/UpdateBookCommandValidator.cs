using FluentValidation;
using Library.Application.Contracts.Persistence;

namespace Library.Application.Features.Book.Commands.UpdateBook;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    private readonly IBookRepository _bookRepository;

    public UpdateBookCommandValidator(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
        RuleFor(x => x.Title).NotEmpty()
            .WithMessage("{PropertyName} is required")
            .MinimumLength(1);
        
        RuleFor(x => x.Author).NotEmpty()
            .WithMessage("{PropertyName} is required")
            .MinimumLength(1);
    }
}