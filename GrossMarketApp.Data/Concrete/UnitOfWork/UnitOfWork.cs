using GrossMarketApp.Core.Abstract.Repositories;
using GrossMarketApp.Core.Abstract.UnitOfWorks;
using GrossMarketApp.Data.Concrete.EntityFramework.Context;
using GrossMarketApp.Data.Concrete.EntityFramework.Repositories;
using System.Threading.Tasks;

namespace GrossMarketApp.Data.Concrete.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private CategoryRepository _categoryRepository;
        private ProductRepository _productRepository;
        private SupplierRepository _supplierRepository;

        private readonly GrossMarketContext _grossMarketContext;
        public UnitOfWork(GrossMarketContext grossMarketContext)
        {
            _grossMarketContext = grossMarketContext;
        }

        public ICategoryRepository Category => _categoryRepository = _categoryRepository
            ?? new CategoryRepository(_grossMarketContext);

        public IProductRepository Product => _productRepository = _productRepository
            ?? new ProductRepository(_grossMarketContext);

        public ISupplierRepository Supplier => _supplierRepository = _supplierRepository
            ?? new SupplierRepository(_grossMarketContext);

        public void Commit()
        {
            _grossMarketContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _grossMarketContext.SaveChangesAsync();
        }
    }
}
