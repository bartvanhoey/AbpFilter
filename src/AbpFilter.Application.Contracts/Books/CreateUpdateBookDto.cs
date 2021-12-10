using System;
using System.ComponentModel.DataAnnotations;
using AbpFilter.Domain.Shared.Books;

namespace AbpFilter.Application.Contracts.Books
{
    public class CreateUpdateBookDto
    {

        [Required] 
        [StringLength(128)]
        public string Name { get; set; }


        [Required] 
        public BookType Type { get; set; }

        [Required]
        [DataType(DataType.Date)] 
        public DateTime PublishDate { get; set; }

        [Required] 
        public float Price { get; set; }
    }
}
