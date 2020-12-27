using GrossMarketApp.Core.Abstract.EntityBases;

namespace GrossMarketApp.Core.Concrete.Entities
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeAge { get; set; }
        public decimal EmployeeSalary { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeePhoneNumber { get; set; }
        public string EmployeeJob { get; set; }
        public bool IsHired { get; set; } = true;
        public bool IsFired { get; set; }
        public bool IsContinuesToWork { get; set; } = true;
    }
}
