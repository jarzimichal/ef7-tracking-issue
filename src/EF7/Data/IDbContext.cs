using System;
using EF7.Domain;
using Microsoft.EntityFrameworkCore;

namespace EF7.Data.Interfaces
{
    public interface IDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : Entity;

        int SaveChanges();

        void Delete<TEntity>(TEntity entity) where TEntity : Entity;
    }
}
