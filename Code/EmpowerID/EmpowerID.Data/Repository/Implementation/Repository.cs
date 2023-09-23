using EmpowerID.Data.Data;
using EmpowerID.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmpowerID.Data.Repository.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDataContext Context;
        public Repository(AppDataContext context)
        {
            Context = context;
        }
        public virtual async Task<TEntity> FindAsync(object id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public TEntity Find(object id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public virtual IQueryable<TEntity> GetAllQuerable()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public virtual IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).AsQueryable();
        }

        public virtual async Task<int> AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            return await Context.SaveChangesAsync();
        }

        public virtual int Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            return Context.SaveChanges();
        }

        public virtual async Task<int> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
            return await Context.SaveChangesAsync();
        }

        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
            return await Context.SaveChangesAsync();
        }

        public virtual async Task<int> UpdateRangeAsync(IEnumerable<TEntity> entity)
        {
            Context.Set<TEntity>().UpdateRange(entity);
            return await Context.SaveChangesAsync();
        }

        public virtual async Task<int> RemoveAsync(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            return await Context.SaveChangesAsync();
        }

        public virtual async Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
            return await Context.SaveChangesAsync();
        }

        public int Count()
        {
            return Context.Set<TEntity>().Count();
        }

    }
    
}
