using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TickTackToe.Data.Repository.Interface;
using TickTackToe.Shared.Entities;

namespace TickTackToe.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public Repository(ApplicationDbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync();

            return entity;
        }

        public async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
            return await SaveAsync();
        }


        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await SaveAsync();

            return entity;
        }

        public async Task<T> GetByAsync(Expression<Func<T, bool>> getBy, bool withTracking = false, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            if (!withTracking)
            {
                //query = query.AsNoTracking();
            }
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.FirstOrDefaultAsync(getBy);
        }

        public async Task<IQueryable<T>> GetAllAsync(bool withTracking = false, params Expression<Func<T, object>>[] includes)
        {
            return await Task.Run(() => GetAll(withTracking, includes));
        }

        public IEnumerable<T> GetAllBy(Expression<Func<T, bool>> getBy, bool withTracking = false, params Expression<Func<T, object>>[] includes)
        {
            return GetAll(withTracking, includes).Where(getBy).AsQueryable();
        }

        public async Task<IQueryable<T>> GetAllByAsync(Expression<Func<T, bool>> getBy, bool withTracking = false, params Expression<Func<T, object>>[] includes)
        {
            return await Task.Run(() => GetAll(withTracking, includes).Where(getBy).AsQueryable());
        }

        public IQueryable<T> GetAll(bool withTracking = false, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            if (!withTracking)
            {
                //query = query.AsNoTracking();
            }
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }

        public IQueryable<T> GetAllInclude<TInclude, TThenInclude>(Expression<Func<T, IEnumerable<TInclude>>> include, Expression<Func<TInclude, TThenInclude>> thenInclude, bool withTracking = false)
             where TInclude : Entity where TThenInclude : Entity
        {
            IQueryable<T> query = _dbSet;
            if (!withTracking)
            {
                //query = query.AsNoTracking();
            }
            if (thenInclude != null)
            {
                return query.Include(include).ThenInclude(thenInclude);
            }
            return query.Include(include);
        }

        public async Task<bool> ExistAsync(Expression<Func<T, bool>> getBy, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            foreach (var include in includes)
            {
                //query = query.Include(include);
            }
            return await query.AsNoTracking().AnyAsync(getBy);
        }

        public async Task<bool> RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
            return await SaveAsync();
        }

        public async Task<bool> RemoveRangeAsync(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            return await SaveAsync();
        }

        private async Task<bool> SaveAsync()
        {
            return (await _dbContext.SaveChangesAsync() >= 0);
        }
    }
}
