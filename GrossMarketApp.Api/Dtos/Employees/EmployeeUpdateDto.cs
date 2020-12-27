using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrossMarketApp.Api.Dtos.Employees
{
    public class EmployeeUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Çalışan Adı")]
        [Required(ErrorMessage = "{0} boş geçmeyiniz")]
        [MaxLength(70, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string EmployeeName { get; set; }

        [DisplayName("Çalışan Yaşı")]
        [Required(ErrorMessage = "{0} boş geçmeyiniz")]
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
