## How to filter a standard paged list in the ABP Framework

## Introduction

In this article, I will show you how to filter a paged list (**Blazorise DataGrid component**) in an ABP Framework application with a Blazor user interface.

The sample application has been developed with **Blazor** as UI framework and **SQL Server** as database provider.

## Source Code

The source code of the completed application is [available on GitHub](https://github.com/bartvanhoey/AbpFilter).

## Requirements

The following tools are needed to run the solution.

- .NET 5.0 SDK
- vscode, Visual Studio 2019, or another compatible IDE.
- ABP Cli

## Development

### Create a new ABP Framework Application

- Install or update the ABP CLI:

```bash
dotnet tool install -g Volo.Abp.Cli || dotnet tool update -g Volo.Abp.Cli
```

- Use the following ABP CLI command to create a new Blazor ABP application:

```bash
abp new AbpFilter -u blazor -o AbpFilter
```

### Open & Run the Application

- Open the solution in Visual Studio (or your favorite IDE).
- Run the `AbpFilter.DbMigrator` application to apply the migrations and seed the initial data.
- Run the `AbpFilter.HttpApi.Host` application to start the server-side.
- Run the `AbpFilter.Blazor` application to start the Blazor UI project.

### BookStore

To have a simple BookStore application to test with, add the code from the [BookStore Tutorial](https://docs.abp.io/en/abp/5.0/Tutorials/Part-1?UI=Blazor&DB=EF) (Part1-2).

## Domain layer

### BookFilter class

Add a **BookFilter** class to the Books folder of the **Domain** project

```csharp
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

```

### IBookRepository interface

Add an **IBookRepository** interface to the Books folder of the **Domain** project.

```csharp
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AbpFilter.Domain.Books
{
    public interface IBookRepository : IRepository<Book, Guid>
    {
        Task<List<Book>> GetListAsync(int skipCount, int maxResultCount, string sorting = "Name", BookFilter filter = null);
        Task<int> GetTotalCountAsync(BookFilter filter);
    }
}
```

## Database layer

## BookRepository class

Add a **BookRepository** class to the Books folder of the **EntityFrameworkCore** project.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbpFilter.Domain.Books;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace AbpFilter.EntityFrameworkCore.Books
{
    public class BookRepository : EfCoreRepository<AbpFilterDbContext, Book, Guid>, IBookRepository
    {
        public BookRepository(IDbContextProvider<AbpFilterDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

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
```

## Application layer

### BookPagedAndSortedResultRequestDto class

Add a **BookPagedAndSortedResultRequestDto** class to the Books folder of the **Application.Contracts** project.
This class inherits the **PagedAndSortedResultRequestDto** class.

```csharp
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
```

### IBookAppService interface

Update the **IBookAppService** interface in the Books folder of the **Application.Contracts** project.

```csharp
using System;
using Volo.Abp.Application.Services;

namespace AbpFilter.Application.Contracts.Books
{
    public interface IBookAppService : ICrudAppService<BookDto, Guid, BookPagedAndSortedResultRequestDto, CreateUpdateBookDto>, IApplicationService
    {
        
    }
}

```

### BookAutoMapperProfile class

Add a **BookAutoMapperProfile** class to the Books folder of the **Application** project.

```csharp
using AbpFilter.Application.Contracts.Books;
using AbpFilter.Domain.Books;
using AutoMapper;

namespace AbpFilter.Application.Books
{
    public class BookAutoMapperProfile : Profile
    {
        public BookAutoMapperProfile()
        {
            CreateMap<BookPagedAndSortedResultRequestDto, BookFilter>();
        }
    }
}

```

### BookAppService class

Override the **GetListAsync** method of the **BookAppService** class in the Books folder of the **Application** project, as in the code below:

```csharp
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

```

### Books.razor page

Override the **DataGrid** component of the **Books.razor** page in the **Blazor** project and Make sure you add the **Filterable** attribute and set it to **true**

```html
@page "/books"
@using Volo.Abp.BlazoriseUI
@using Volo.Abp.AspNetCore.Components.Web
@using AbpFilter.Application.Contracts.Books
@using AbpFilter.Localization
@using Microsoft.Extensions.Localization
@inject IStringLocalizer<AbpFilterResource> L
@inject AbpBlazorMessageLocalizerHelper<AbpFilterResource> LH
@inherits AbpCrudPageBase<IBookAppService, BookDto, Guid, BookPagedAndSortedResultRequestDto, CreateUpdateBookDto>

<Card>
  <CardBody>
    <DataGrid TItem="BookDto" Filterable="true" Data="Entities" ReadData="OnDataGridReadAsync" TotalItems="TotalCount" ShowPager="true" PageSize="PageSize">
      <DataGridColumns>
        <DataGridEntityActionsColumn TItem="BookDto" @ref="@EntityActionsColumn">
          <DisplayTemplate>
            <EntityActions TItem="BookDto" EntityActionsColumn="@EntityActionsColumn">
              <EntityAction TItem="BookDto" Text="@L["Edit"]" Visible="HasUpdatePermission" Clicked="() => OpenEditModalAsync(context)" />
              <EntityAction TItem="BookDto" Text="@L["Delete"]" Visible="HasDeletePermission" Clicked="() => DeleteEntityAsync(context)" ConfirmationMessage="() => GetDeleteConfirmationMessage(context)" />
            </EntityActions>
          </DisplayTemplate>
        </DataGridEntityActionsColumn>
        <DataGridColumn TItem="BookDto" Field="@nameof(BookDto.Id)" Caption="Id"></DataGridColumn>
        <DataGridColumn TItem="BookDto" Field="@nameof(BookDto.Name)" Caption="Name"></DataGridColumn>
        <DataGridColumn TItem="BookDto" Field="@nameof(BookDto.PublishDate)" Caption="Publish date"></DataGridColumn>
        <DataGridColumn TItem="BookDto" Field="@nameof(BookDto.Price)" Caption="Price"></DataGridColumn>
      </DataGridColumns>
    </DataGrid>
  </CardBody>
</Card>
```

### Books.razor.cs class

Override the **UpdateGetListInputAsync** and **OnDataGridReadAsync** methods as you can see below:

```csharp
using System.Linq;
using System.Threading.Tasks;
using AbpFilter.Application.Contracts.Books;
using Blazorise.DataGrid;
using Volo.Abp.Application.Dtos;

namespace AbpFilter.Blazor.Pages
{
    public partial class Books
    {
        protected override Task UpdateGetListInputAsync()
        {
            if (GetListInput is ISortedResultRequest sortedResultRequestInput)
            {
                sortedResultRequestInput.Sorting = CurrentSorting;
            }

            if (GetListInput is IPagedResultRequest pagedResultRequestInput)
            {
                pagedResultRequestInput.SkipCount = (CurrentPage - 1) * PageSize;
            }

            if (GetListInput is ILimitedResultRequest limitedResultRequestInput)
            {
                limitedResultRequestInput.MaxResultCount = PageSize;

            }
            return Task.CompletedTask;
        }

        protected override Task OnDataGridReadAsync(DataGridReadDataEventArgs<BookDto> e)
        {
            var id = e.Columns.FirstOrDefault(c => c.SearchValue != null && c.Field == "Id");
            if (id != null) this.GetListInput.Id = id.SearchValue.ToString();

            var name = e.Columns.FirstOrDefault(c => c.SearchValue != null && c.Field == "Name");
            if (name != null) this.GetListInput.Name = name.SearchValue.ToString();

            var publishDate = e.Columns.FirstOrDefault(c => c.SearchValue != null && c.Field == "PublishDate");
            if (publishDate != null) this.GetListInput.PublishDate = publishDate.SearchValue.ToString();

            var price = e.Columns.FirstOrDefault(c => c.SearchValue != null && c.Field == "Price");
            if (price != null) this.GetListInput.Price = price.SearchValue.ToString();

            return base.OnDataGridReadAsync(e);
        }
    }
}

```

## Test the result

### Start both the Blazor and the **HttpApi.Host** project to run the application

Et voilà! You can now filter a standard paged list (**Blazorise DataGrid component**) in the ABP Framework.

![Filtering in action](/Images/recording.gif)

Get the [source code](https://github.com/bartvanhoey/AbpFilter.git) on GitHub.

Enjoy and have fun!
