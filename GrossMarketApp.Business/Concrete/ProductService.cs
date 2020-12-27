using GrossMarketApp.Core.Abstract.Repositories;
using GrossMarketApp.Core.Abstract.Results;
using GrossMarketApp.Core.Abstract.Services;
using GrossMarketApp.Core.Abstract.UnitOfWorks;
using GrossMarketApp.Core.Concrete.Entities;
using GrossMarketApp.Core.Concrete.Results;
using System;
using System.Threading.Tasks;

namespace GrossMarketApp.Business.Concrete
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {
        }

        public bool ControlBarcodeNumber(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<Product>> GetProductWithCategoryByIdAsync(int productId)
        {
            var isProduct = await _unitOfWork.Product.GetByIdAsync(productId);

            if (isProduct == null)
                return new DataResult<Product>(ResultStatus.Error, null);
            else
            {
                var product = await _unitOfWork.Product.GetProductWithCategoryByIdAsync(productId);

                if (product == null)
                    return new DataResult<Product>(ResultStatus.Error, null);

                return new DataResult<Product>(ResultStatus.Success, product);
            }
        }

        public async Task<IDataResult<Product>> GetProductWithSupplierByIdAsync(int productId)
        {
            var isProduct = await _unitOfWork.Product.GetByIdAsync(productId);

            if (isProduct == null)
                return new DataResult<Product>(ResultStatus.Error, null);
            else
            {
                var product = await _unitOfWork.Product.GetProductWithSupplierByIdAsync(productId);

                if (product == null)
                    return new DataResult<Product>(ResultStatus.Error, null);

                return new DataResult<Product>(ResultStatus.Success, product);
            }
        }
    }
}
