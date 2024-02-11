using Volo.Abp.Application.Dtos;

namespace AbpFilter.Books
{
    public class BookPagedAndSortedResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string? Id { get; set; } = "";
        public string? Name { get; set; } = "";
        public string? PublishDate { get; set; } = "";
        public string? Price { get; set; } = "";
    }
}