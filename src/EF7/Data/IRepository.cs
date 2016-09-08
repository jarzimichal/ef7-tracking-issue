using System;
using System.Linq.Expressions;
using EF7.Domain;

namespace EF7.Data.Interfaces
{
    public interface IRepository
    {
        void Delete<TEntity>(TEntity entity) where TEntity : Entity;

        System.Linq.IQueryable<TEntity> GetAll<TEntity>() where TEntity : Entity;

        System.Linq.IQueryable<TEntity> GetAll<TEntity>(params Expression<Func<TEntity, object>>[] includes) where TEntity : Entity;

        TEntity GetById<TEntity>(int id) where TEntity : Entity;

        void Insert<TEntity>(TEntity entity) where TEntity : Entity;

        void SaveChanges();

        TEntity GetBy<TEntity>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes) where TEntity : Entity;
    }
}
