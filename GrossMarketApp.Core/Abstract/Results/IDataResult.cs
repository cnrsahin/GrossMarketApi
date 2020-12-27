namespace GrossMarketApp.Core.Abstract.Results
{
    public interface IDataResult<out T> : IResult
    {
        public T Data { get; }
    }
}
