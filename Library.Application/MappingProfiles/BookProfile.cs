using AutoMapper;
using Library.Application.Features.Book.Queries.GetAllBooks;
using Library.Application.Features.Book.Queries.GetBookDetails;
using Library.Domain;

namespace Library.Application.MappingProfiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<BookDto, Book>().ReverseMap();
        CreateMap<BookDetailsDto, Book>().ReverseMap();
    }
}