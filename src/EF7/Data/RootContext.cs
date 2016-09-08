using System;
using Microsoft.EntityFrameworkCore;
using EF7.Data.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using EF7.Domain;

namespace EF7.Data
{
    public enum DbAction
    {
        Add,
        Modify,
        Delete
    }

    public class RootContext : DbContext, IDbContext
    {
        public RootContext(DbContextOptions<RootContext> options)
            : base(options)
        {
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : Entity
        {
            return base.Set<TEntity>();
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : Entity
        {
            Set<TEntity>().Remove(entity);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parent>();
            modelBuilder.Entity<Child>();
            modelBuilder.Entity<Toy>();

            // Add more entities here...

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entity.Name.EndsWith("s")
                    ? entity.Name.Replace("EF7.Domain.", "") + "es"
                    : entity.Name.Replace("EF7.Domain.", "") + "s";

                modelBuilder.Entity(entity.Name).ToTable(tableName);
            }

            //Remove cascading deletes
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }

        

    }
}