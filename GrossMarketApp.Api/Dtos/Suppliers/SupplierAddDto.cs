using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrossMarketApp.Api.Dtos.Suppliers
{
    public class SupplierAddDto
    {
        public string SupplierName { get; set; }
        public string SupplierPhoneNumber { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierEmailAddress { get; set; }
        public string Note { get; set; }
    }
}
