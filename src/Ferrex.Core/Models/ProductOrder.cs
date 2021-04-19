using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ferrex.Core.Models
{
    public class ProductOrder
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string OrderNumber { get; set; }
        [Required]
        [Display(Name = "Producto")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [Required]
        [Range(1, 100000)]
        [Display(Name = "Cantidad a solicitar")]
        public int RequestedStock { get; set; }
        public double Total { get; set; } = 0.00;
        public string Comment { get; set; }
        public bool Accepted { get; set; } = false;
        public bool Entered { get; set; } = false;
        public DateTime ReviewedOn { get; set; }
    }
}
