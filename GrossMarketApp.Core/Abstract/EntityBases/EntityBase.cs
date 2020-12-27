using System;

namespace GrossMarketApp.Core.Abstract.EntityBases
{
    public abstract class EntityBase
    {
        public virtual int Id { get; set; }
        public virtual string Note { get; set; } = "İlgili konuda not tutabilirsiniz.";
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
