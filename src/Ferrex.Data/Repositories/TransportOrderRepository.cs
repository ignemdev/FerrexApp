using Ferrex.Core.Models;
using Ferrex.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ferrex.Data.Repositories
{
    public class TransportOrderRepository : Repository<TransportOrder>, ITransportOrderRepository
    {
        private readonly FerrexContext _db;

        public TransportOrderRepository(FerrexContext db) : base(db)
        {
            _db = db;
        }
        public async Task UpdateAsync(TransportOrder transportOrder)
        {
            var dbTransportOrder = await _db.TransportOrders
                .FirstOrDefaultAsync(p => p.OrderNumber == transportOrder.OrderNumber);

            if (dbTransportOrder is not null)
            {
                dbTransportOrder.TruckDescription = transportOrder.TruckDescription;
                dbTransportOrder.Total = dbTransportOrder.Total;
                dbTransportOrder.Comment = dbTransportOrder.Comment;
                dbTransportOrder.Accepted = dbTransportOrder.Accepted;
                dbTransportOrder.ReviewedOn = dbTransportOrder.ReviewedOn;
            }
        }
    }
}
