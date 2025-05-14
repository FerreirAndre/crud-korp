using MediatR;

namespace Library.Application.Features.Book.Commands.UpdateBook;

public class UpdateBookCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Summary { get; set; } = String.Empty;
}