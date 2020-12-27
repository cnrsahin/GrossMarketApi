using GrossMarketApp.Core.Abstract.Repositories;
using GrossMarketApp.Core.Abstract.Results;
using GrossMarketApp.Core.Abstract.Services;
using GrossMarketApp.Core.Abstract.UnitOfWorks;
using GrossMarketApp.Core.Concrete.Entities;
using GrossMarketApp.Core.Concrete.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrossMarketApp.Business.Concrete
{
    public class SupplierService : Service<Supplier>, ISupplierService
    {
        public SupplierService(IUnitOfWork unitOfWork, IRepository<Supplier> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<IDataResult<Supplier>> GetSupplierWithProductsByIdAsync(int supplierId)
        {
            var isSupplier = await _unitOfWork.Supplier.GetByIdAsync(supplierId);

            if (isSupplier == null)
                return new DataResult<Supplier>(ResultStatus.Error, null);
            else
            {
                var supplier = await _unitOfWork.Supplier.GetSupplierWithProductsByIdAsync(supplierId);

                if (supplier == null)
                    return new DataResult<Supplier>(ResultStatus.Error, null);

                return new DataResult<Supplier>(ResultStatus.Success, supplier);
            }
        }
    }
}
