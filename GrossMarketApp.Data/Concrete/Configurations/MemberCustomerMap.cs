using GrossMarketApp.Core.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrossMarketApp.Data.Concrete.Configurations
{
    public class MemberCustomerMap : IEntityTypeConfiguration<MemberCustomer>
    {
        public void Configure(EntityTypeBuilder<MemberCustomer> builder)
        {
            builder.HasKey(memberCustomer => memberCustomer.Id);
            builder.Property(memberCustomer => memberCustomer.Id).UseIdentityColumn();
            builder.Property(memberCustomer => memberCustomer.Note).HasMaxLength(500);
            builder.Property(memberCustomer => memberCustomer.CreatedDate).IsRequired();
            builder.Property(memberCustomer => memberCustomer.ModifiedDate).IsRequired();
            builder.ToTable("MemberCustomers");

            builder.Property(memberCustomer => memberCustomer.MemberCustomerName).IsRequired().HasMaxLength(70);
            builder.Property(memberCustomer => memberCustomer.MemberCustomerAge).IsRequired().HasMaxLength(3);
            builder.Property(memberCustomer => memberCustomer.MemberCustomerPhoneNumber).IsRequired().HasMaxLength(15);
        }
    }
}
