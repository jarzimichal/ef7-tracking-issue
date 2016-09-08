using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using EF7.Data.Interfaces;
using EF7.Domain;

namespace EF7.Data.Repositories
{
    /// <summary>
    /// Base repository.
    /// </summary>
	public class Repository : IRepository, IDisposable
    {
        private readonly IDbContext _context;

        public Repository(IDbContext context)
        {
            this._context = context;
        }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : Entity
        {
            return GetEntities<TEntity>();
        }

        public IQueryable<TEntity> GetAll<TEntity>(params Expression<Func<TEntity, object>>[] includes) where TEntity : Entity
        {
            var result = GetAll<TEntity>();
            if (includes.Any())
            {
                result = includes.Aggregate(result, (current, include) => current.Include(include));
            }
            return result;
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : Entity
        {
            GetEntities<TEntity>().Add(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : Entity
        {
            _context.Delete(entity);
        }

        private DbSet<TEntity> GetEntities<TEntity>() where TEntity : Entity
        {
            return _context.Set<TEntity>();
        }

        public TEntity GetById<TEntity>(int id) where TEntity : Entity
        {
            return GetAll<TEntity>().SingleOrDefault(item => item.IdRow == id);
        }

        public TEntity GetBy<TEntity>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes) where TEntity : Entity
        {
            var result = GetAll(includes);
            return result.FirstOrDefault(predicate);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        #region IDisposable

        private bool _disposed;

        /// <summary>
        /// Dispose the <see cref="DbContext"/>.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _context?.Dispose();
            }

            _disposed = true;
        }

        #endregion IDisposable
    }
}
