using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmpowerID.Data.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> FindAsync(object id);
        TEntity Find(object id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IQueryable<TEntity> GetAllQuerable();
        int Count();
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate);
        Task<int> AddAsync(TEntity entity);
        int Add(TEntity entity);
        Task<int> AddRangeAsync(IEnumerable<TEntity> entities);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> UpdateRangeAsync(IEnumerable<TEntity> entity);
        Task<int> RemoveAsync(TEntity entity);

        Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities);
    }
}
