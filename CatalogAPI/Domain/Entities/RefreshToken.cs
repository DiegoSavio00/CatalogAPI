using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CatalogAPI.Domain.Entities
{
    public class RefreshToken
    {
        [Key]
        [StringLength(50)]
        public string Userid { get; set; } = null!;
        [StringLength(50)]
        public string? Tokenid { get; set; }
        public string? Refreshtoken { get; set; }
    }
}
