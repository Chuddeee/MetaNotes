using MetaNotes.Core.Services;

[assembly: InternalsVisibleTo("MetaNotes.Infrastructure.DependencyResolution")]
namespace MetaNotes.Infrastructure.Data.EF
{
    /// <summary>Базовый класс для сервисов</summary>
    internal abstract class BaseService
    {
        private readonly IUnitOfWork _uow;

        public BaseService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected IUnitOfWork UnitOfWork
        {
            get { return _uow; }
        }
    }
}
