using MetaNotes.Core.Entities;
using MetaNotes.Core.Services;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MetaNotes.Infrastructure.Data.EF
{
    /// <summary>Реализация репозитория для EF</summary>
    internal sealed class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbContext _dbContext;
        private DbSet<TEntity> _dbSet;

        public EfRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Select(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return _dbSet;
            }

            return _dbSet.Where(predicate);
        }

        public TEntity Add(TEntity entity)
        {
            return _dbSet.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            Attach(entity);
            _dbSet.Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        private void Attach(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
        }
    }
}
