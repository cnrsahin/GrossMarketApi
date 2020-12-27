using GrossMarketApp.Core.Abstract.Repositories;
using GrossMarketApp.Core.Concrete.Entities;
using GrossMarketApp.Data.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GrossMarketApp.Data.Concrete.EntityFramework.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private GrossMarketContext _myContext
        {
            get => _context as GrossMarketContext;
        }
        public CategoryRepository(GrossMarketContext context) : base(context)
        {
        }

        public async Task<Category> GetCategoryWithProductsByIdAsync(int categoryId)
        {
            return await _myContext.Categories.Include(category => category.Products)
                .SingleOrDefaultAsync(category => category.Id == categoryId);
        }
    }
}
