using System;
using System.ComponentModel.DataAnnotations;

namespace Ferrex.Core.Models
{
    public class TransportOrder
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string OrderNumber { get; set; }
        public string TruckDescription { get; set; }
        [Required]
        [Range(1, 100000)]
        [Display(Name = "Kilometros a solicitar")]
        public int RequestedKilometers { get; set; }
        [Required]
        [Display(Name = "Dia de solicitud")]
        [MyDate(ErrorMessage = "Invalid date")]
        public DateTime RequestedDay { get; set; }
        public double Total { get; set; } = 0.00;
        public string Comment { get; set; }
        public bool Accepted { get; set; } = false;
        public DateTime ReviewedOn { get; set; }
    }

    public class MyDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime d = Convert.ToDateTime(value);
            return d > DateTime.Now;

        }
    }
}
