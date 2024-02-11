using System.Linq;
using System.Threading.Tasks;
using AbpFilter.Books;
using Blazorise.DataGrid;
using Volo.Abp.Application.Dtos;
using static System.String;

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
            GetListInput.Id = id != null && !IsNullOrEmpty(id.SearchValue.ToString()) ? id.SearchValue.ToString(): Empty;
            
            var name = e.Columns.FirstOrDefault(c => c.SearchValue != null && c.Field == "Name");
            GetListInput.Name = name != null && !IsNullOrEmpty(name.SearchValue.ToString()) ? name.SearchValue.ToString() : Empty;

            var publishDate = e.Columns.FirstOrDefault(c => c.SearchValue != null && c.Field == "PublishDate");
            GetListInput.PublishDate = publishDate != null && !IsNullOrEmpty(publishDate.SearchValue.ToString()) ? publishDate.SearchValue.ToString() : Empty;
            
            var price = e.Columns.FirstOrDefault(c => c.SearchValue != null && c.Field == "Price");
            GetListInput.Price =  price != null && !IsNullOrEmpty(price.SearchValue.ToString()) ? price.SearchValue.ToString() :Empty;

            return base.OnDataGridReadAsync(e);
        }
    }
}