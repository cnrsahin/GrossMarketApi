using AutoMapper;
using GrossMarketApp.Api.Dtos.MemberCustomers;
using GrossMarketApp.Core.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrossMarketApp.Api.Profiles
{
    public class MemberCustomerProfile : Profile
    {
        public MemberCustomerProfile()
        {
            CreateMap<MemberCustomersAddDto, MemberCustomer>().ForMember(d => d.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<MemberCustomerListDelete, MemberCustomer>();
            CreateMap<MemberCustomerUpdateDto, MemberCustomer>().ForMember(d => d.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
        }
    }
}
