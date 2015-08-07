using MetaNotes.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
