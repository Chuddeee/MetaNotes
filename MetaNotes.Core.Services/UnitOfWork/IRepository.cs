using MetaNotes.Core.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MetaNotes.Core.Services
{
    /// <summary>Репозиторий для работы с сущностями</summary>
    /// <typeparam name="TEntity">Тип сущности, с которой работает репозиторий</typeparam>
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> Select(Expression<Func<TEntity, bool>> predicate = null);

        TEntity Add(TEntity entity);

        void Remove(TEntity entity);

        TEntity Update(TEntity entity);       
    }
}
