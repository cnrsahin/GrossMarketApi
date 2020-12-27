using GrossMarketApp.Core.Concrete.Results;
using System;

namespace GrossMarketApp.Core.Abstract.Results
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; }
        public Exception Exception { get; }
    }
}
