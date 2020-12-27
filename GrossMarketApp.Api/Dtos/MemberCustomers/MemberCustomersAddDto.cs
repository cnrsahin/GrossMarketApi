using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrossMarketApp.Api.Dtos.MemberCustomers
{
    public class MemberCustomersAddDto
    {
        [DisplayName("Üye Müşteri Adı")]
        [Required(ErrorMessage = "{0} boş geçmeyiniz")]
        [MaxLength(70, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string MemberCustomerName { get; set; }

        [DisplayName("Üye Müşteri Yaşı")]
        [Required(ErrorMessage = "{0} boş geçmeyiniz")]
        public int MemberCustomerAge { get; set; }
        public string MemberCustomerPhoneNumber { get; set; }
        public string Note { get; set; }
    }
}
