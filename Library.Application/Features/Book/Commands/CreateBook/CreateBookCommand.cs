using MediatR;

namespace Library.Application.Features.Book.Commands.CreateBook;

public class CreateBookCommand : IRequest<int>
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Summary { get; set; }
}