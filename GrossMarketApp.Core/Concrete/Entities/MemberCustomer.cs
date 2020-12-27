using GrossMarketApp.Core.Abstract.EntityBases;

namespace GrossMarketApp.Core.Concrete.Entities
{
    public class MemberCustomer : EntityBase, IEntity
    {
        public string MemberCustomerName { get; set; }
        public int MemberCustomerAge { get; set; }
        public string MemberCustomerPhoneNumber { get; set; }
    }
}
