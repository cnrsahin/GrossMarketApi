using GrossMarketApp.Core.Abstract.Repositories;
using System.Threading.Tasks;

namespace GrossMarketApp.Core.Abstract.UnitOfWorks
{
    public interface IUnitOfWork
    {
        public ICategoryRepository Category { get; }
        public IProductRepository Product { get; }
        public ISupplierRepository Supplier { get; }

        void Commit();
        Task CommitAsync();
    }
}
