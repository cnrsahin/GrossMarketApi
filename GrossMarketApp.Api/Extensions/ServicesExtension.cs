using AutoMapper;
using GrossMarketApp.Api.Profiles;
using GrossMarketApp.Business.Concrete;
using GrossMarketApp.Core.Abstract.Repositories;
using GrossMarketApp.Core.Abstract.Services;
using GrossMarketApp.Core.Abstract.UnitOfWorks;
using GrossMarketApp.Data.Concrete.EntityFramework.Context;
using GrossMarketApp.Data.Concrete.EntityFramework.Repositories;
using GrossMarketApp.Data.Concrete.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrossMarketApp.Api.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection ServicesExtensionMethod(this IServiceCollection serviceDescriptors, string myConnectingString)
        {
            serviceDescriptors.AddDbContext<GrossMarketContext>(options =>
            {
                options.UseSqlServer(myConnectingString, opt =>
                {
                    opt.MigrationsAssembly("GrossMarketApp.Data");
                });
            });

            serviceDescriptors.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceDescriptors.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            serviceDescriptors.AddScoped(typeof(IService<>), typeof(Service<>));
            serviceDescriptors.AddScoped<ICategoryService, CategoryService>();
            serviceDescriptors.AddScoped<IProductService, ProductService>();
            serviceDescriptors.AddScoped<ISupplierService, SupplierService>();

            serviceDescriptors.AddAutoMapper(typeof(CategoryProfile), typeof(ProductProfile)
                , typeof(SupplierProfile), typeof(MemberCustomerProfile), typeof(EmployeeProfile));

            return serviceDescriptors;
        }
    }
}
