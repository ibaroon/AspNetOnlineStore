using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public class ProductVm
    {
        // data anotation

        [Required]
        [DisplayName("Category Name")]
        [MinLength(1)]
        public string CatName { get; set; }
        [Required]
        [DisplayName("Product Name")]
        [MaxLength(50)]
        public string ProductName { get; set; }
        public string Name { get; set; }
        [Required]
        [DisplayName("Product Price")]
        public decimal ProductPrice { get; set; }
        public decimal Price { get; set; }
        [DisplayName("Product Qty")]
        public int ProductQuan { get; set; }
        public int Quan { get; set; }
        [DisplayName("Product Description")]
        public string ProductDesc { get; set; }
        public string Description { get; set; }
        public int CatId { get; set; }
        public int Id { get; set; }
        public IFormFile File { get; set; }
        public DateOnly CreatedAt { get; set; }

    }
}
