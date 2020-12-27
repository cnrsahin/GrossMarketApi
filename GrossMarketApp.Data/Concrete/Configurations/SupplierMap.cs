using GrossMarketApp.Core.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrossMarketApp.Data.Concrete.Configurations
{
    public class SupplierMap : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(supplier => supplier.Id);
            builder.Property(supplier => supplier.Id).UseIdentityColumn();
            builder.Property(supplier => supplier.Note).HasMaxLength(500);
            builder.Property(supplier => supplier.CreatedDate).IsRequired();
            builder.Property(supplier => supplier.ModifiedDate).IsRequired();
            builder.ToTable("Suppliers");

            builder.Property(supplier => supplier.SupplierName).IsRequired().HasMaxLength(70);
            builder.Property(supplier => supplier.SupplierPhoneNumber).IsRequired().HasMaxLength(15);
            builder.Property(supplier => supplier.SupplierAddress).IsRequired().HasMaxLength(500);
            builder.Property(supplier => supplier.SupplierEmailAddress).IsRequired().HasMaxLength(70);
        }
    }
}
