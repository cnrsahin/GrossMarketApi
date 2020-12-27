using GrossMarketApp.Core.Abstract.EntityBases;
using GrossMarketApp.Core.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrossMarketApp.Api.Dtos.Products
{
    public class ProductListDto : DtosBase
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
