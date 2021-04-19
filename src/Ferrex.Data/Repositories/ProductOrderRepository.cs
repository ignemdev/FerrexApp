using Ferrex.Core.Models;
using Ferrex.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ferrex.Data.Repositories
{
    public class ProductOrderRepository : Repository<ProductOrder>, IProductOrderRepository
    {
        private readonly FerrexContext _db;
        public ProductOrderRepository(FerrexContext db) : base(db)
        {
            _db = db;
        }

        public async Task UpdateAsync(ProductOrder productOrder)
        {
            var dbProductOrder = await _db.ProductOrders
                .FirstOrDefaultAsync(p => p.OrderNumber == productOrder.OrderNumber);

            if (dbProductOrder is not null)
            {
                dbProductOrder.Total = productOrder.Total;
                dbProductOrder.Comment = productOrder.Comment;
                dbProductOrder.Accepted = productOrder.Accepted;
                dbProductOrder.ReviewedOn = productOrder.ReviewedOn;
            }
        }
    }
}
