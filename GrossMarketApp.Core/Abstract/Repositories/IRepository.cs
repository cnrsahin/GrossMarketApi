using GrossMarketApp.Core.Abstract.EntityBases;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GrossMarketApp.Core.Abstract.Repositories
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();

        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);

        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);

        T Update(T entity);

        Task<IEnumerable<T>> SearchNameAsync(Expression<Func<T, bool>> predicate);
    }
}
