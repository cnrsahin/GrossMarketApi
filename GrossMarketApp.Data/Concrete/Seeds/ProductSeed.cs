using GrossMarketApp.Core.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GrossMarketApp.Data.Concrete.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    CategoryId = 1,
                    SupplierId = 1,
                    ProductName = "Zeytin Yağı 1lt",
                    BarcodeNumber = Guid.NewGuid(),
                    Stock = 28,
                    Price = 60m,
                    Note = "Süzme zeytin yağı 1 litrelik şişe",
                    ProductionDate = DateTime.Now - TimeSpan.FromDays(60),
                    ExpiryDate = DateTime.Now + TimeSpan.FromDays(365),
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new Product
                {
                    Id = 2,
                    CategoryId = 2,
                    SupplierId = 2,
                    ProductName = "Dana Eti",
                    BarcodeNumber = Guid.NewGuid(),
                    Stock = 78,
                    Price = 55m,
                    Note = "1Kg dana eti",
                    ProductionDate = DateTime.Now - TimeSpan.FromDays(60),
                    ExpiryDate = DateTime.Now + TimeSpan.FromDays(365),
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new Product
                {
                    Id = 3,
                    CategoryId = 3,
                    SupplierId = 3,
                    ProductName = "Salkım Domates",
                    BarcodeNumber = Guid.NewGuid(),
                    Stock = 120,
                    Price = 11m,
                    Note = "1Kg salkım ihraç domates",
                    ProductionDate = DateTime.Now - TimeSpan.FromDays(60),
                    ExpiryDate = DateTime.Now + TimeSpan.FromDays(365),
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                }
            );
        }
    }
}
