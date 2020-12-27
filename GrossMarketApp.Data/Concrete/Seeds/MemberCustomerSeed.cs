using GrossMarketApp.Core.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GrossMarketApp.Data.Concrete.Seeds
{
    public class MemberCustomerSeed : IEntityTypeConfiguration<MemberCustomer>
    {
        public void Configure(EntityTypeBuilder<MemberCustomer> builder)
        {
            builder.HasData(
                new MemberCustomer
                {
                    Id = 1,
                    MemberCustomerName = "Çiğdem Erdoğan",
                    MemberCustomerAge = 22,
                    MemberCustomerPhoneNumber = "+908516342272",
                    Note = "Yeni müşteri, üyelik kartı satın aldı.",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new MemberCustomer
                {
                    Id = 2,
                    MemberCustomerName = "Nurcan Arslan",
                    MemberCustomerAge = 32,
                    MemberCustomerPhoneNumber = "+908513277329",
                    Note = "Yeni müşteri, üyelik kartı satın aldı.",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new MemberCustomer
                {
                    Id = 3,
                    MemberCustomerName = "Bayram Köse",
                    MemberCustomerAge = 48,
                    MemberCustomerPhoneNumber = "+908514856593",
                    Note = "Yeni müşteri, üyelik kartı satın aldı.",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                }
            );
        }
    }
}
