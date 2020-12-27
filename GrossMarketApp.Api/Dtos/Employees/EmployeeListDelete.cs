using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrossMarketApp.Api.Dtos.Employees
{
    public class EmployeeListDelete
    {     
        [Required(ErrorMessage = "{0} boş geçmeyiniz")]
        public int Id { get; set; }
    }
}
