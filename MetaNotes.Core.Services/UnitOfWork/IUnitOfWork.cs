using MetaNotes.Core.Entities;
using System;
using System.Threading.Tasks;

namespace MetaNotes.Core.Services
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>Возвращает репозиторий</summary>
        /// <typeparam name="TEntity">Тип сущности, с которой работает репозиторий</typeparam>
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
