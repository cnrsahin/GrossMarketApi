using AutoMapper;
using GrossMarketApp.Api.Dtos.Products;
using GrossMarketApp.Core.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrossMarketApp.Api.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductToCategoryDto>().ReverseMap();
            CreateMap<Product, ProductToSupplierDto>().ReverseMap();
            CreateMap<ProductListDelete, Product>().ReverseMap();
            CreateMap<Product, ProductAddDto>().ReverseMap().ForMember(d => d.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<ProductUpdateDto, Product>().ForMember(d => d.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Product, ProductWithCategoryDto>().ReverseMap();
            CreateMap<Product, ProductWithSupplierDto>().ReverseMap();
        }
    }
}
