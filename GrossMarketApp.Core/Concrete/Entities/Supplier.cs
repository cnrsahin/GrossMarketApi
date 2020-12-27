using GrossMarketApp.Core.Abstract.EntityBases;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace GrossMarketApp.Core.Concrete.Entities
{
    public class Supplier : EntityBase, IEntity
    {
        public Supplier()
        {
            Products = new Collection<Product>();
        }

        public string SupplierName { get; set; }
        public string SupplierPhoneNumber { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierEmailAddress { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
