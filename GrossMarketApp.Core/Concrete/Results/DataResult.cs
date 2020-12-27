using GrossMarketApp.Core.Abstract.Results;
using System;

namespace GrossMarketApp.Core.Concrete.Results
{
    public class DataResult<T> : IDataResult<T>
    {
        public ResultStatus ResultStatus { get; }
        public Exception Exception { get; }
        public T Data { get; }

        public DataResult(ResultStatus resultStatus, T data)
        {
            ResultStatus = resultStatus;
            Data = data;
        }

        public DataResult(ResultStatus resultStatus, T data, Exception exception)
        {
            ResultStatus = resultStatus;
            Data = data;
            Exception = exception;
        }
    }
}
