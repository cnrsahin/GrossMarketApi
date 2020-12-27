using GrossMarketApp.Api.Dtos.Suppliers;
using GrossMarketApp.Core.Abstract.EntityBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrossMarketApp.Api.Dtos.Products
{
    public class ProductWithSupplierDto : DtosBase
    {
        public SupplierToProductDto Supplier { get; set; }
    
    }
}
