using Ferrex.Core.Models;
using Ferrex.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ferrex.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly FerrexContext _db;

        public CategoryRepository(FerrexContext db) : base(db)
        {
            _db = db;
        }
        public async Task UpdateAsync(Category category)
        {
            var dbCategory = await _db.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);

            if (dbCategory is not null)
            {
                dbCategory.Name = category.Name;
                dbCategory.Description = category.Description;
            }
        }
    }
}
