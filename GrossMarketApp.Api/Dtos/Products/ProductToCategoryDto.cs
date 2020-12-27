using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrossMarketApp.Api.Dtos.Products
{
    public class ProductToCategoryDto
    {
        public int Id { get; set; }

        [DisplayName("Ürün Adı")]
        [Required(ErrorMessage = "{0} boş geçmeyiniz")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string ProductName { get; set; }

        [DisplayName("Ürün Stock Adedi")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} alani 1'den buyuk bir deger olmalidir")]
        public int Stock { get; set; }

        [DisplayName("Ürün Fiyatı")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} alani 1 TL'den buyuk bir deger olmalidir")]
        public decimal Price { get; set; }

        [DisplayName("Ürün Kategori Id")]
        public int CategoryId { get; set; }

        public int SupplierId { get; set; }

        public DateTime ProductionDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Guid BarcodeNumber { get; set; }
    }
}
