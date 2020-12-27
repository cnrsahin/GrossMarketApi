using GrossMarketApp.Core.Abstract.EntityBases;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GrossMarketApp.Core.Concrete.Entities
{
    public class Category : EntityBase, IEntity
    {
        public Category()
        {
            Products = new Collection<Product>();
        }

        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
