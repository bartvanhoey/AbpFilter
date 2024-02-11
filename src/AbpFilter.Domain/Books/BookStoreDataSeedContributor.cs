using System;
using System.Threading.Tasks;
using AbpFilter.Domain.Books;
using AbpFilter.Domain.Shared.Books;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace AbpFilter.Books
{
    public class BooksDataSeedContributor(IRepository<Book, Guid> bookRepository)
        : IDataSeedContributor, ITransientDependency
    {
        public async Task SeedAsync(DataSeedContext context)
        {
            if (await bookRepository.GetCountAsync() <= 0)
            {
                await bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "1984",
                        Type = BookType.Dystopia,
                        PublishDate = new DateTime(1949, 6, 8),
                        Price = 19.84f
                    },
                    autoSave: true
                );

                await bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "The Hitchhiker's Guide to the Galaxy",
                        Type = BookType.ScienceFiction,
                        PublishDate = new DateTime(1995, 9, 27),
                        Price = 42.0f
                    },
                    autoSave: true
                );

                await bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "ULYSSES",
                        Type = BookType.Fantastic,
                        PublishDate = new DateTime(1922, 6, 8),
                        Price = 89.84f
                    },
                    autoSave: true
                );

                await bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "The way of all flesh",
                        Type = BookType.Horror,
                        PublishDate = new DateTime(1873, 6, 8),
                        Price = 77.9f
                    },
                    autoSave: true
                );

                await bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "Go tell it on the mountain",
                        Type = BookType.Dystopia,
                        PublishDate = new DateTime(1953, 10, 12),
                        Price = 65.65f
                    },
                    autoSave: true
                );

                await bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "THE SOUND AND THE FURY",
                        Type = BookType.Dystopia,
                        PublishDate = new DateTime(1949, 6, 8),
                        Price = 19.84f
                    },
                    autoSave: true
                );

                await bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "APPOINTMENT IN SAMARRA",
                        Type = BookType.ScienceFiction,
                        PublishDate = new DateTime(1995, 9, 27),
                        Price = 42.0f
                    },
                    autoSave: true
                );

                await bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "THE GOLDEN BOWL",
                        Type = BookType.Fantastic,
                        PublishDate = new DateTime(1922, 6, 8),
                        Price = 89.84f
                    },
                    autoSave: true
                );

                await bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "NOSTROMO",
                        Type = BookType.Horror,
                        PublishDate = new DateTime(1873, 6, 8),
                        Price = 77.9f
                    },
                    autoSave: true
                );

                await bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "OF HUMAN BONDAGE",
                        Type = BookType.Dystopia,
                        PublishDate = new DateTime(1953, 10, 12),
                        Price = 65.65f
                    },
                    autoSave: true
                );


                await bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "A CLOCKWORK ORANGE",
                        Type = BookType.Dystopia,
                        PublishDate = new DateTime(1949, 6, 8),
                        Price = 19.84f
                    },
                    autoSave: true
                );

                await bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "HEART OF DARKNESS",
                        Type = BookType.ScienceFiction,
                        PublishDate = new DateTime(1995, 9, 27),
                        Price = 42.0f
                    },
                    autoSave: true
                );

                await bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "A ROOM WITH A VIEW",
                        Type = BookType.Fantastic,
                        PublishDate = new DateTime(1922, 6, 8),
                        Price = 89.84f
                    },
                    autoSave: true
                );

                await bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "HE CALL OF THE WILD",
                        Type = BookType.Horror,
                        PublishDate = new DateTime(1873, 6, 8),
                        Price = 77.9f
                    },
                    autoSave: true
                );

                await bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "TOBACCO ROAD",
                        Type = BookType.Dystopia,
                        PublishDate = new DateTime(1953, 10, 12),
                        Price = 65.65f
                    },
                    autoSave: true
                );
            }
        }
    }
}