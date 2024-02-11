using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AbpFilter.Domain.Books;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpFilter.Books
{
    public class BookAppService(IBookRepository bookRepository)
        : CrudAppService<Book, BookDto, Guid, BookPagedAndSortedResultRequestDto, CreateUpdateBookDto>(bookRepository),
            IBookAppService
    {
        public override async Task<PagedResultDto<BookDto>> GetListAsync(BookPagedAndSortedResultRequestDto input)
        {
            var filter = ObjectMapper.Map<BookPagedAndSortedResultRequestDto, BookFilter>(input);

            var sorting = (string.IsNullOrEmpty(input.Sorting) ? "Name DESC" : input.Sorting).Replace("ShortName", "Name");

            var books = await bookRepository.GetListAsync(input.SkipCount, input.MaxResultCount, sorting, filter);
            var totalCount = await bookRepository.GetTotalCountAsync(filter);

            return new PagedResultDto<BookDto>(totalCount,ObjectMapper.Map<List<Book>, List<BookDto>>(books));
        }
    }
}