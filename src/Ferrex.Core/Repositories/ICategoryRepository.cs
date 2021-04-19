using Ferrex.Core.Models;
using System.Threading.Tasks;

namespace Ferrex.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task UpdateAsync(Category category);
    }
}
