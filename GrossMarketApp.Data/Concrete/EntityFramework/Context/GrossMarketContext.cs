using GrossMarketApp.Core.Concrete.Entities;
using GrossMarketApp.Data.Concrete.Configurations;
using GrossMarketApp.Data.Concrete.Seeds;
using Microsoft.EntityFrameworkCore;

namespace GrossMarketApp.Data.Concrete.EntityFramework.Context
{
    public class GrossMarketContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<MemberCustomer> MemberCustomers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public GrossMarketContext(DbContextOptions<GrossMarketContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new SupplierMap());
            modelBuilder.ApplyConfiguration(new MemberCustomerMap());
            modelBuilder.ApplyConfiguration(new EmployeeMap());

            modelBuilder.ApplyConfiguration(new CategorySeed());
            modelBuilder.ApplyConfiguration(new ProductSeed());
            modelBuilder.ApplyConfiguration(new SupplierSeed());
            modelBuilder.ApplyConfiguration(new MemberCustomerSeed());
            modelBuilder.ApplyConfiguration(new EmployeeSeed());
        }
    }
}
