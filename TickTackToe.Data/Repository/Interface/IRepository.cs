using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TickTackToe.Shared.Entities;

namespace TickTackToe.Data.Repository.Interface
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> AddAsync(T entity);
        Task<bool> AddRangeAsync(IEnumerable<T> entities);
        Task<T> UpdateAsync(T entity);

        Task<T> GetByAsync(Expression<Func<T, bool>> getBy, bool withTracking = false, params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetAll(bool withTracking = false, params Expression<Func<T, object>>[] includes);
        Task<IQueryable<T>> GetAllAsync(bool withTracking = false, params Expression<Func<T, object>>[] includes);
        IEnumerable<T> GetAllBy(Expression<Func<T, bool>> getBy, bool withTracking = false, params Expression<Func<T, object>>[] includes);
        Task<IQueryable<T>> GetAllByAsync(Expression<Func<T, bool>> getBy, bool withTracking = false, params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetAllInclude<TInclude, TThenInclude>(Expression<Func<T, IEnumerable<TInclude>>> include, Expression<Func<TInclude, TThenInclude>> thenInclude, bool withTracking = false)
            where TInclude : Entity where TThenInclude : Entity;
        Task<bool> ExistAsync(Expression<Func<T, bool>> getBy, params Expression<Func<T, object>>[] includes);
        Task<bool> RemoveAsync(T entity);
        Task<bool> RemoveRangeAsync(IEnumerable<T> entities);
    }
}