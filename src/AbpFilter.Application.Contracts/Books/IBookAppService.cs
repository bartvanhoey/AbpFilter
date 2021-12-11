using System;
using Volo.Abp.Application.Services;

namespace AbpFilter.Application.Contracts.Books
{
    public interface IBookAppService : ICrudAppService<BookDto, Guid, BookPagedAndSortedResultRequestDto, CreateUpdateBookDto>, IApplicationService
    {
        
    }
}
