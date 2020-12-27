using GrossMarketApp.Core.Concrete.Entities;
using System.Threading.Tasks;

namespace GrossMarketApp.Core.Abstract.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetProductWithCategoryByIdAsync(int productId);
        Task<Product> GetProductWithSupplierByIdAsync(int productId);
    }
}
