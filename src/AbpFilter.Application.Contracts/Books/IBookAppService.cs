using System;
using Volo.Abp.Application.Services;

namespace AbpFilter.Books
{
    public interface IBookAppService : ICrudAppService<BookDto, Guid, BookPagedAndSortedResultRequestDto, CreateUpdateBookDto>;
}