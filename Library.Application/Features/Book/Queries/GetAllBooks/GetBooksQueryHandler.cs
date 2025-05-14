using AutoMapper;
using Library.Application.Contracts.Persistence;
using MediatR;

namespace Library.Application.Features.Book.Queries.GetAllBooks;

public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, List<BookDto>>
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;

    public GetBooksQueryHandler(IBookRepository BookRepository,IMapper mapper)
    {
        _mapper = mapper;
        _bookRepository = BookRepository;
    }
    public async Task<List<BookDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetAsync();
        var data = _mapper.Map<List<BookDto>>(books);
        return data;
    }
}