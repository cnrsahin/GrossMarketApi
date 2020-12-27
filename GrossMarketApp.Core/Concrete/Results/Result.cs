using GrossMarketApp.Core.Abstract.Results;
using System;

namespace GrossMarketApp.Core.Concrete.Results
{
    public class Result : IResult
    {
        public ResultStatus ResultStatus { get; }
        public Exception Exception { get; }

        public Result(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }

        public Result(ResultStatus resultStatus, Exception exception)
        {
            ResultStatus = resultStatus;
            Exception = exception;
        }
    }
}
