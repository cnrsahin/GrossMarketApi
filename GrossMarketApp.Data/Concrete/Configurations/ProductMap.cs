using GrossMarketApp.Core.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrossMarketApp.Data.Concrete.Configurations
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.Id);
            builder.Property(product => product.Id).UseIdentityColumn();
            builder.Property(product => product.Note).HasMaxLength(500);
            builder.Property(product => product.CreatedDate).IsRequired();
            builder.Property(product => product.ModifiedDate).IsRequired();
            builder.ToTable("Products");

            builder.Property(product => product.ProductName).IsRequired().HasMaxLength(70);
            builder.Property(product => product.Stock).IsRequired();
            builder.Property(product => product.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(product => product.ProductionDate).IsRequired();
            builder.Property(product => product.ExpiryDate).IsRequired();
            builder.Property(product => product.BarcodeNumber).HasMaxLength(50);

            builder.HasOne<Category>(product => product.Category).WithMany(category => category.Products)
                .HasForeignKey(product => product.CategoryId);

            builder.HasOne<Supplier>(product => product.Supplier).WithMany(supplier => supplier.Products)
                .HasForeignKey(product => product.SupplierId);
        }
    }
}
