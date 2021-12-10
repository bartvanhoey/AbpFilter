using System;
using AbpFilter.Domain.Shared.Books;
using Volo.Abp.Application.Dtos;

namespace AbpFilter.Application.Contracts.Books
{
    public class BookPagedAndSortedResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PublishDate { get; set; }
        public string Price { get; set; }
    }
}
