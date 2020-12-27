using GrossMarketApp.Core.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrossMarketApp.Data.Concrete.Configurations
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(category => category.Id);
            builder.Property(category => category.Id).UseIdentityColumn();
            builder.Property(category => category.Note).HasMaxLength(500);
            builder.Property(category => category.CreatedDate).IsRequired();
            builder.Property(category => category.ModifiedDate).IsRequired();
            builder.ToTable("Categories");

            builder.Property(category => category.CategoryName).IsRequired().HasMaxLength(50);
        }
    }
}
