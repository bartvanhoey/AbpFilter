using System;

namespace AbpFilter.Domain.Books
{
    public class BookFilter
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PublishDate { get; set; }
        public string Price { get; set; }
    }
}
