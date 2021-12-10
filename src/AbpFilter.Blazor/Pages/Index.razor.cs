using System.Linq;
using System.Threading.Tasks;
using AbpFilter.Application.Contracts.Books;
using Blazorise.DataGrid;
using Volo.Abp.Application.Dtos;

namespace AbpFilter.Blazor.Pages
{
    public partial class Index
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
