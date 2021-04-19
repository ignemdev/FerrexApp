using Ferrex.Core.Models;
using System.Threading.Tasks;

namespace Ferrex.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task UpdateAsync(Product product);
    }
}
