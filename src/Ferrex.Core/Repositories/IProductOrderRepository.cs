using Ferrex.Core.Models;
using System.Threading.Tasks;

namespace Ferrex.Core.Repositories
{
    public interface IProductOrderRepository : IRepository<ProductOrder>
    {
        Task UpdateAsync(ProductOrder productOrder);
    }
}
