using GrossMarketApp.Core.Abstract.EntityBases;
using System;

namespace GrossMarketApp.Core.Concrete.Entities
{
    public class Product : EntityBase, IEntity
    {
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Guid BarcodeNumber { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public int SupplierId { get; set; }
    }
}
