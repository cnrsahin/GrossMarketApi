using GrossMarketApp.Api.Dtos.Products;
using GrossMarketApp.Core.Abstract.EntityBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrossMarketApp.Api.Dtos.Suppliers
{
    public class SupplierWithProductsDto : DtosBase
    {
        public IEnumerable<ProductToSupplierDto> Products { get; set; }
    }
}
