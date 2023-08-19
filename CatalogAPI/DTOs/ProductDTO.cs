using CatalogAPI.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogAPI.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required"), MinLength(3), MaxLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required"), MinLength(5), MaxLength(200)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [MaxLength(250)]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Enter the register date")]
        public DateTime RegisterDate { get; set; }
        public int CategoryId { get; set; }
    }
}
