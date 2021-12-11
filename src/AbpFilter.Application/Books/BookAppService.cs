using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AbpFilter.Application.Contracts.Books;
using AbpFilter.Domain.Books;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpFilter.Application.Books
{
    public class BookAppService : CrudAppService<Book, BookDto, Guid, BookPagedAndSortedResultRequestDto, CreateUpdateBookDto>, IBookAppService
    {
        private readonly IBookRepository _bookRepository;

        public BookAppService(IBookRepository bookRepository) : base(bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public override async Task<PagedResultDto<BookDto>> GetListAsync(BookPagedAndSortedResultRequestDto input)
        {
            var filter = ObjectMapper.Map<BookPagedAndSortedResultRequestDto, BookFilter>(input);

            var sorting = (string.IsNullOrEmpty(input.Sorting) ? "Name DESC" : input.Sorting).Replace("ShortName", "Name");
           
            var books = await _bookRepository.GetListAsync(input.SkipCount, input.MaxResultCount, sorting, filter);
            var totalCount = await _bookRepository.GetTotalCountAsync(filter);

            return new PagedResultDto<BookDto>(totalCount,ObjectMapper.Map<List<Book>, List<BookDto>>(books));
        }
    }
}
