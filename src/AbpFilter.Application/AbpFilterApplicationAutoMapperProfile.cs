using AbpFilter.Application.Contracts.Books;
using AbpFilter.Domain.Books;
using AutoMapper;

namespace AbpFilter
{
    public class AbpFilterApplicationAutoMapperProfile : Profile
    {
        public AbpFilterApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

             CreateMap<Book, BookDto>();
             CreateMap<CreateUpdateBookDto, Book>();
        }
    }
}
