using GrossMarketApp.Core.Abstract.Results;
using GrossMarketApp.Core.Concrete.Entities;
using System.Threading.Tasks;

namespace GrossMarketApp.Core.Abstract.Services
{
    public interface IProductService : IService<Product>
    {
        Task<IDataResult<Product>> GetProductWithCategoryByIdAsync(int productId);
        Task<IDataResult<Product>> GetProductWithSupplierByIdAsync(int productId);
        bool ControlBarcodeNumber(Product product);
    }
}
