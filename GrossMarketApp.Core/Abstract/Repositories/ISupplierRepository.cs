using GrossMarketApp.Core.Concrete.Entities;
using System.Threading.Tasks;

namespace GrossMarketApp.Core.Abstract.Repositories
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<Supplier> GetSupplierWithProductsByIdAsync(int supplierId);
    }
}
