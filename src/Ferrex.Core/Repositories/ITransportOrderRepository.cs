using Ferrex.Core.Models;
using System.Threading.Tasks;

namespace Ferrex.Core.Repositories
{
    public interface ITransportOrderRepository : IRepository<TransportOrder>
    {
        Task UpdateAsync(TransportOrder transportOrder);
    }
}
