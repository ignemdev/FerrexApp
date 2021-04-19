using System;

namespace Ferrex.Core.DTOs
{
    public class TransportOrderDTO
    {
        public string OrderNumber { get; set; }
        //editar
        public string TruckDescription { get; set; }
        public int RequestedKilometers { get; set; }
        public DateTime RequestedDay { get; set; }
        //editar
        public double Total { get; set; }
        //editar
        public string Comment { get; set; }
        //editar
        public bool Accepted { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
