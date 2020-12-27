using AutoMapper;
using GrossMarketApp.Api.Dtos.Suppliers;
using GrossMarketApp.Core.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrossMarketApp.Api.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<SupplierAddDto, Supplier>().ForMember(d => d.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<SupplierListDelete, Supplier>();
            CreateMap<SupplierUpdateDto, Supplier>().ForMember(d => d.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Supplier, SupplierWithProductsDto>().ReverseMap();
            CreateMap<Supplier, SupplierToProductDto>().ReverseMap();
        }
    }
}
