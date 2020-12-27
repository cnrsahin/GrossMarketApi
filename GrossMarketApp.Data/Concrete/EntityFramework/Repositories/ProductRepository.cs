using GrossMarketApp.Core.Abstract.Repositories;
using GrossMarketApp.Core.Concrete.Entities;
using GrossMarketApp.Data.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GrossMarketApp.Data.Concrete.EntityFramework.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private GrossMarketContext _myContext
        {
            get => _context as GrossMarketContext;
        }

        public ProductRepository(GrossMarketContext context) : base(context)
        {
        }

        public async Task<Product> GetProductWithCategoryByIdAsync(int productId)
        {
            return await _myContext.Products.Include(product => product.Category)
                .SingleOrDefaultAsync(product => product.Id == productId);
        }

        public async Task<Product> GetProductWithSupplierByIdAsync(int productId)
        {
            return await _myContext.Products.Include(product => product.Supplier)
                .SingleOrDefaultAsync(product => product.Id == productId);
        }
    }
}
