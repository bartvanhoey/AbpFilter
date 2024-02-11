using AbpFilter.Books;
using AbpFilter.Domain.Books;
using AutoMapper;

namespace AbpFilter;

public class AbpFilterApplicationAutoMapperProfile : Profile
{
    public AbpFilterApplicationAutoMapperProfile()
    {
        CreateMap<BookPagedAndSortedResultRequestDto, BookFilter>();
        CreateMap<Book, BookDto>();   
        CreateMap<CreateUpdateBookDto, Book>();      
    }
}
