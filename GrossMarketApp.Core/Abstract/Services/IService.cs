using GrossMarketApp.Core.Abstract.EntityBases;
using GrossMarketApp.Core.Abstract.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GrossMarketApp.Core.Abstract.Services
{
    public interface IService<T> where T : class, IEntity, new()
    {
        Task<IDataResult<T>> GetByIdAsync(int id);
        Task<IDataResult<IEnumerable<T>>> GetAllAsync();

        Task<IResult> AddAsync(T entity);
        Task<IResult> AddRangeAsync(IEnumerable<T> entities);

        IResult Delete(T entity);
        IResult DeleteRange(IEnumerable<T> entities);

        IDataResult<T> Update(T entity);

        Task<IDataResult<IEnumerable<T>>> SearchNameAsync(Expression<Func<T, bool>> predicate);
    }
}
