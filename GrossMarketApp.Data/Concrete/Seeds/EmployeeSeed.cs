using GrossMarketApp.Core.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrossMarketApp.Data.Concrete.Seeds
{
    public class EmployeeSeed : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee
                {
                    Id = 1,
                    EmployeeName = "İsmail Çakır",
                    EmployeeAddress = "Ramiz Mahallesi No:609 Sındırgı, Balıkesir",
                    EmployeeAge = 24,
                    EmployeeJob = "Kasiyer",
                    EmployeePhoneNumber = "+908512730226",
                    EmployeeSalary = 2600m,
                    IsContinuesToWork = true,
                    IsHired = true,
                    IsFired = false
                },
                new Employee
                {
                    Id = 2,
                    EmployeeName = "Ezgi Bulut",
                    EmployeeAddress = "Dolgun Caddesi No:394 Ağaçören, Aksaray",
                    EmployeeAge = 41,
                    EmployeeJob = "Manav",
                    EmployeePhoneNumber = "+908511660275",
                    EmployeeSalary = 2300m,
                    IsContinuesToWork = true,
                    IsHired = true,
                    IsFired = false
                },
                new Employee
                {
                    Id = 3,
                    EmployeeName = "Hasan Köse",
                    EmployeeAddress = "Buse Mahallesi No:129 Türkeli, Sinop",
                    EmployeeAge = 34,
                    EmployeeJob = "Kasap",
                    EmployeePhoneNumber = "+908512897057",
                    EmployeeSalary = 3100m,
                    IsContinuesToWork = true,
                    IsHired = true,
                    IsFired = false
                }
            );
        }
    }
}
