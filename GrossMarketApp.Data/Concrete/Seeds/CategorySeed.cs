using GrossMarketApp.Core.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GrossMarketApp.Data.Concrete.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = 1,
                    CategoryName = "Yağ Ürünleri",
                    Note = "Sıvı ve Katı Yağ Kategorisi",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new Category
                {
                    Id = 2,
                    CategoryName = "Kasap Ürünleri",
                    Note = "Kırmızı ve Beyaz Et Kategorisi",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new Category
                {
                    Id = 3,
                    CategoryName = "Manav Ürünleri",
                    Note = "Meyve ve Sebze Ürünleri",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                }
            );
        }
    }
}
