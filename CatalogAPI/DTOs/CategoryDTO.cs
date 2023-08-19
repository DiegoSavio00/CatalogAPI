using System.ComponentModel.DataAnnotations;

namespace CatalogAPI.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter the name of the category")]
        [MinLength(3), MaxLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter the name of image")]
        [MinLength(5), MaxLength(255)]
        public string ImageUrl { get; set; }
    }
}
