using GrossMarketApp.Core.Abstract.EntityBases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrossMarketApp.Api.Dtos.Products
{
    public class ProductAddDto
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public decimal Price { get; set; }
        public DateTime ProductionDate { get; set; } = DateTime.Now - TimeSpan.FromDays(60);
        public DateTime ExpiryDate { get; set; } = DateTime.Now + TimeSpan.FromDays(365);
        public Guid BarcodeNumber { get; set; } = Guid.NewGuid();

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int SupplierId { get; set; }

        public string Note { get; set; }
    }
}
