using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AbpFilter.Domain.Books;
using AbpFilter.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AbpFilter.Books
{
    public class BookRepository(IDbContextProvider<AbpFilterDbContext> dbContextProvider)
        : EfCoreRepository<AbpFilterDbContext, Book, Guid>(dbContextProvider), IBookRepository
    {
        public async Task<List<Book>> GetListAsync(int skipCount, int maxResultCount, string sorting = "Name", BookFilter filter = null)
        {
            var dbSet = await GetDbSetAsync();
            var books = await dbSet
                .WhereIf(!filter.Id.IsNullOrWhiteSpace(), x => x.Id.ToString().Contains(filter.Id))
                .WhereIf(!filter.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(filter.Name))
                .WhereIf(!filter.Price.IsNullOrWhiteSpace(), x => x.Price.ToString().Contains(filter.Price))
                .WhereIf(!filter.PublishDate.IsNullOrWhiteSpace(), x => x.PublishDate.ToString().Contains(filter.PublishDate))
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
            return books;
        }

        public async Task<int> GetTotalCountAsync(BookFilter filter)
        {
            var dbSet = await GetDbSetAsync();
            var books = await dbSet
                .WhereIf(!filter.Id.IsNullOrWhiteSpace(), x => x.Id.ToString().Contains(filter.Id))
                .WhereIf(!filter.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(filter.Name))
                .WhereIf(!filter.Price.IsNullOrWhiteSpace(), x => x.Price.ToString().Contains(filter.Price))
                .WhereIf(!filter.PublishDate.IsNullOrWhiteSpace(), x => x.PublishDate.ToString().Contains(filter.PublishDate))
                .ToListAsync();
            return books.Count;
        }
    }
}