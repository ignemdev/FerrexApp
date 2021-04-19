using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ferrex.Core.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }
        [Required]
        [Range(1, 100000)]
        [Display(Name = "Precio")]
        public double Price { get; set; }
        [Range(0, 100000)]
        public int Stock { get; set; } = 0;
        public string Image { get; set; }
        [Required]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
