using Ferrex.Core.Models;
using Ferrex.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ferrex.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly FerrexContext _db;

        public ProductRepository(FerrexContext db) : base(db) => _db = db;

        public async Task UpdateAsync(Product product)
        {
            var dbProduct = await _db.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

            if (dbProduct is not null)
            {
                dbProduct.Name = product.Name;
                dbProduct.Description = product.Description;
                dbProduct.Price = product.Price;
                dbProduct.CategoryId = product.CategoryId;
            }

        }

        public async Task AddStockAsync(Product product)
        {
            var dbProduct = await _db.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

            if (dbProduct is not null) dbProduct.Stock += product.Stock;
        }
    }
}
