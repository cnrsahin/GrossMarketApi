using GrossMarketApp.Core.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GrossMarketApp.Data.Concrete.Seeds
{
    public class SupplierSeed : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasData(
                new Supplier
                {
                    Id = 1,
                    SupplierName = "Destek Gıda",
                    SupplierAddress = "Ayfer Caddesi No:656 Kurşunlu, Çankırı",
                    SupplierEmailAddress = "info@mail.com",
                    SupplierPhoneNumber = "+908515083726",
                    Note = "Yiyecek ve içecek tedarikçisi",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new Supplier
                {
                    Id = 2,
                    SupplierName = "Besa Gıda",
                    SupplierAddress = "Adnan Menderes Bulvarı No:136 Görele, Giresun",
                    SupplierEmailAddress = "info@mail.com",
                    SupplierPhoneNumber = "+908512279812",
                    Note = "Yiyecek ve içecek tedarikçisi",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new Supplier
                {
                    Id = 3,
                    SupplierName = "Öz Trakya Gıda",
                    SupplierAddress = "Kaçkar Bulvarı No:800 Palu, Elazığ",
                    SupplierEmailAddress = "info@mail.com",
                    SupplierPhoneNumber = "+908516990496",
                    Note = "Yiyecek ve içecek tedarikçisi",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                }
            );
        }
    }
}
