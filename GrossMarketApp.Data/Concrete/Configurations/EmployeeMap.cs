using GrossMarketApp.Core.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrossMarketApp.Data.Concrete.Configurations
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(employee => employee.Id);
            builder.Property(employee => employee.Id).UseIdentityColumn();
            builder.Property(employee => employee.EmployeeName).IsRequired().HasMaxLength(70);
            builder.Property(employee => employee.EmployeeAge).IsRequired().HasMaxLength(3);
            builder.Property(employee => employee.EmployeeSalary).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(employee => employee.EmployeeAddress).IsRequired().HasMaxLength(500);
            builder.Property(employee => employee.EmployeePhoneNumber).IsRequired().HasMaxLength(15);
            builder.Property(employee => employee.EmployeeJob).IsRequired().HasMaxLength(30);
            builder.Property(employee => employee.IsHired).IsRequired();
            builder.Property(employee => employee.IsFired).IsRequired();
            builder.Property(employee => employee.IsContinuesToWork).IsRequired();

            builder.ToTable("Employees");
        }
    }
}
