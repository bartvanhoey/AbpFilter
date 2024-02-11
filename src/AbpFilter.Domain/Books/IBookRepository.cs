using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AbpFilter.Domain.Books;
using Volo.Abp.Domain.Repositories;

namespace AbpFilter.Books
{
    public interface IBookRepository : IRepository<Book, Guid>
    {
        Task<List<Book>> GetListAsync(int skipCount, int maxResultCount, string sorting = "Name", BookFilter? filter = null);
        Task<int> GetTotalCountAsync(BookFilter filter);
    }
}