using Ferrex.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace Ferrex.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IProductOrderRepository ProductOrder { get; }
        ITransportOrderRepository TransportOrder { get; }
        Task SaveAsync();
    }
}
