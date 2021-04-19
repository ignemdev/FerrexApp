using Ferrex.Core;
using Ferrex.Core.Repositories;
using Ferrex.Data.Repositories;
using System.Threading.Tasks;

namespace Ferrex.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FerrexContext _db;

        public UnitOfWork(FerrexContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
