using GrossMarketApp.Core.Abstract.Results;
using GrossMarketApp.Core.Concrete.Entities;
using System.Threading.Tasks;

namespace GrossMarketApp.Core.Abstract.Services
{
    public interface ISupplierService : IService<Supplier>
    {
        Task<IDataResult<Supplier>> GetSupplierWithProductsByIdAsync(int supplierId);
    }
}
