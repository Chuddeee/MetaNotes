using MetaNotes.Core.Services;

namespace MetaNotes.Infrastructure.Data.EF
{
    public class BaseService
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
