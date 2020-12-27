using GrossMarketApp.Core.Abstract.Repositories;
using GrossMarketApp.Core.Concrete.Entities;
using GrossMarketApp.Data.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GrossMarketApp.Data.Concrete.EntityFramework.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        private GrossMarketContext _myContext
        {
            get => _context as GrossMarketContext;
        }
        public SupplierRepository(GrossMarketContext context) : base(context)
        {
        }

        public async Task<Supplier> GetSupplierWithProductsByIdAsync(int supplierId)
        {
            return await _myContext.Suppliers.Include(supplier => supplier.Products)
                .SingleOrDefaultAsync(supplier => supplier.Id == supplierId);
        }
    }
}
