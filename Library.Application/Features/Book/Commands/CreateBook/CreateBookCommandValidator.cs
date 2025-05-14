using FluentValidation;
using Library.Application.Contracts.Persistence;

namespace Library.Application.Features.Book.Commands.CreateBook;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    private readonly IBookRepository _bookRepository;

    public CreateBookCommandValidator(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
        RuleFor(x => x.Title).NotEmpty()
            .WithMessage("{PropertyName} is required")
            .MinimumLength(1);

        RuleFor(x => x.Author).NotEmpty()
            .WithMessage("{PropertyName} is required")
            .MinimumLength(1);

        RuleFor(x => x)
            .MustAsync(BookTitleUnique)
            .WithMessage("Book name already exists");

        this._bookRepository = bookRepository;
    }

    private Task<bool> BookTitleUnique(CreateBookCommand request, CancellationToken cancellationToken)
    {
        return _bookRepository.IsBookTitleUnique(request.Title);
    }
}