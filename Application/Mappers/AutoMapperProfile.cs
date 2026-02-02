using AutoMapper;
using BookStore1.Application.DTOs.Books;
using BookStore1.Domain;

namespace BookStore1.Application.Mappers
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.Author,
                    opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.Category,
                    opt => opt.MapFrom(src => src.Category.Name));
        }
    }

}
