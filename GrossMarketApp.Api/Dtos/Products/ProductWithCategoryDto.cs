using GrossMarketApp.Api.Dtos.Categories;
using GrossMarketApp.Core.Abstract.EntityBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrossMarketApp.Api.Dtos.Products
{
    public class ProductWithCategoryDto : DtosBase
    {
        public CategoryToProductDto Category { get; set; }
    }
}
