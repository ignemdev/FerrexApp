using System;

namespace Ferrex.Core.DTOs
{
    public class ProductOrderDTO
    {
        public string OrderNumber { get; set; }
        public string ProductName { get; set; }
        public int RequestedStock { get; set; }
        //editar
        public double Total { get; set; }
        //editar
        public string Comment { get; set; }
        //editar
        public bool Accepted { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
