using GrossMarketApp.Core.Abstract.EntityBases;
using GrossMarketApp.Core.Abstract.Repositories;
using GrossMarketApp.Core.Abstract.Results;
using GrossMarketApp.Core.Abstract.Services;
using GrossMarketApp.Core.Abstract.UnitOfWorks;
using GrossMarketApp.Core.Concrete.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GrossMarketApp.Business.Concrete
{
    public class Service<T> : IService<T> where T : class, IEntity, new()
    {
        protected readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<T> _repository;

        public Service(IUnitOfWork unitOfWork, IRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<IResult> AddAsync(T entity)
        {
            if (entity == null)
                return new Result(ResultStatus.Error);
            else
            {
                await _repository.AddAsync(entity);
                await _unitOfWork.CommitAsync();

                return new Result(ResultStatus.Success);
            }
        }

        public async Task<IResult> AddRangeAsync(IEnumerable<T> entities)
        {
            if (entities == null)
                return new Result(ResultStatus.Error);
            else
            {
                await _repository.AddRangeAsync(entities);
                await _unitOfWork.CommitAsync();

                return new Result(ResultStatus.Success);
            }
        }

        public IResult Delete(T entity)
        {
            if (entity == null)
                return new Result(ResultStatus.Error);
            else
            {
                _repository.Delete(entity);
                _unitOfWork.Commit();

                return new Result(ResultStatus.Success);
            }
        }

        public IResult DeleteRange(IEnumerable<T> entities)
        {
            if (entities == null)
                return new Result(ResultStatus.Error);
            else
            {
                _repository.DeleteRange(entities);
                _unitOfWork.Commit();

                return new Result(ResultStatus.Success);
            }
        }

        public async Task<IDataResult<IEnumerable<T>>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();

            if (entities == null)
                return new DataResult<IEnumerable<T>>(ResultStatus.Error, null);
            return new DataResult<IEnumerable<T>>(ResultStatus.Success, entities);
        }

        public async Task<IDataResult<T>> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
                return new DataResult<T>(ResultStatus.Error, null);
            return new DataResult<T>(ResultStatus.Success, entity);
        }

        public async Task<IDataResult<IEnumerable<T>>> SearchNameAsync(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
                return new DataResult<IEnumerable<T>>(ResultStatus.Error, null);

            var entity = await _repository.SearchNameAsync(predicate);

            if (entity == null)
                return new DataResult<IEnumerable<T>>(ResultStatus.Error, null);
            return new DataResult<IEnumerable<T>>(ResultStatus.Success, entity);
        }

        public IDataResult<T> Update(T entity)
        {
            if (entity == null)
                return new DataResult<T>(ResultStatus.Error, null);
            else
            {
                var newEntity = _repository.Update(entity);
                _unitOfWork.Commit();

                return new DataResult<T>(ResultStatus.Success, newEntity);
            }
        }
    }
}
