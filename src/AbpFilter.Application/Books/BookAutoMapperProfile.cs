using AbpFilter.Application.Contracts.Books;
using AbpFilter.Domain.Books;
using AutoMapper;

namespace AbpFilter.Application.Books
{
    public class BookAutoMapperProfile : Profile
    {
        public BookAutoMapperProfile()
        {
            CreateMap<BookPagedAndSortedResultRequestDto, BookFilter>();
        }
    }
}
