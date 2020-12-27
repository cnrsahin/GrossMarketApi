using GrossMarketApp.Core.Concrete.Results;

namespace GrossMarketApp.Core.Abstract.EntityBases
{
    public abstract class DtosBase
    {
        public virtual ResultStatus ResultStatus { get; set; }
        public virtual string Message { get; set; }
    }
}
