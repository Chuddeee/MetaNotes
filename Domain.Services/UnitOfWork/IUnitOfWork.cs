using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.Services.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>Возвращает экземпляр сервиса</summary>
        /// <typeparam name="TEntity">Тип сущности, с которой работает репозиторий</typeparam>
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;

        void SaveChanges();

        Task SaveChangesAsync();

        void BeginTransaction();

        void RollBackTransaction();

        void CommitTransaction();
    }
}
