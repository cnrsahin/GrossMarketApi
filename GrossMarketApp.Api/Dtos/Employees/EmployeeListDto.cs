using GrossMarketApp.Core.Abstract.EntityBases;
using GrossMarketApp.Core.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrossMarketApp.Api.Dtos.Employees
{
    public class EmployeeListDto : DtosBase
    {
        public IEnumerable<Employee> Employees { get; set; }
    }
}
