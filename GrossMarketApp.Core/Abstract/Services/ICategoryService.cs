using GrossMarketApp.Core.Abstract.Results;
using GrossMarketApp.Core.Concrete.Entities;
using System.Threading.Tasks;

namespace GrossMarketApp.Core.Abstract.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<IDataResult<Category>> GetCategoryWithProductsByIdAsync(int categoryId);
    }
}
