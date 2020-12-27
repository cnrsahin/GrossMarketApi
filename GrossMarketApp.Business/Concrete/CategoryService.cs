using GrossMarketApp.Core.Abstract.Repositories;
using GrossMarketApp.Core.Abstract.Results;
using GrossMarketApp.Core.Abstract.Services;
using GrossMarketApp.Core.Abstract.UnitOfWorks;
using GrossMarketApp.Core.Concrete.Entities;
using GrossMarketApp.Core.Concrete.Results;
using System.Threading.Tasks;

namespace GrossMarketApp.Business.Concrete
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<IDataResult<Category>> GetCategoryWithProductsByIdAsync(int categoryId)
        {
            var isCategory = await _unitOfWork.Category.GetByIdAsync(categoryId);

            if (isCategory == null)
                return new DataResult<Category>(ResultStatus.Error, null);
            else
            {
                var category = await _unitOfWork.Category.GetCategoryWithProductsByIdAsync(categoryId);

                if (category == null)
                    return new DataResult<Category>(ResultStatus.Error, null);

                return new DataResult<Category>(ResultStatus.Success, category);
            }
        }
    }
}
