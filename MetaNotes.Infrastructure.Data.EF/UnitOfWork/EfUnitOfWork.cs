using MetaNotes.Core.Entities;
using MetaNotes.Core.Services;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace MetaNotes.Infrastructure.Data.EF
{
    public sealed class EfUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private bool _disposed = false;

        public EfUnitOfWork(DbContext context)
        {
            _dbContext = context;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity
        {
            return new EfRepository<TEntity>(_dbContext);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        #region IDisposable

        private void Dispose(bool disposeContext)
        {
            if (!_disposed && disposeContext)
            {
                _dbContext.Dispose();
            }

            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
