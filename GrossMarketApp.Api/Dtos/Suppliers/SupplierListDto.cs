using GrossMarketApp.Core.Abstract.EntityBases;
using GrossMarketApp.Core.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrossMarketApp.Api.Dtos.Suppliers
{
    public class SupplierListDto : DtosBase
    {
        public IEnumerable<Supplier> Suppliers { get; set; }
    }
}
