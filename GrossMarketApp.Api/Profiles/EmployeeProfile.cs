using AutoMapper;
using GrossMarketApp.Api.Dtos.Employees;
using GrossMarketApp.Core.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrossMarketApp.Api.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeesAddDto, Employee>();
            CreateMap<EmployeeListDelete, Employee>();
            CreateMap<EmployeeUpdateDto, Employee>();
        }
    }
}
