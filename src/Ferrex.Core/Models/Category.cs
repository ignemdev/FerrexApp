using System;
using System.ComponentModel.DataAnnotations;

namespace Ferrex.Core.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
