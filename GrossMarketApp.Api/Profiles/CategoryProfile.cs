using AutoMapper;
using GrossMarketApp.Api.Dtos.Categories;
using GrossMarketApp.Api.Dtos.Products;
using GrossMarketApp.Core.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrossMarketApp.Api.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>().ForMember(d => d.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<CategoryListDelete, Category>();
            CreateMap<CategoryUpdateDto, Category>().ForMember(d => d.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Category, CategoryWithProductsDto>().ReverseMap();
            CreateMap<Category, CategoryToProductDto>().ReverseMap();
        }
    }
}
