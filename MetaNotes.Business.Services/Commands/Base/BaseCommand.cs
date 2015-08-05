using MetaNotes.Core.Services;
using System;
using System.Threading.Tasks;

namespace MetaNotes.Business.Services.Commands.Base
{
    public abstract class BaseCommand<TArguments, TResult> : ICommand<TArguments, TResult>
        where TArguments : ICommandArguments
        where TResult : ICommandResult
    {
        private readonly IUnitOfWork _uow;

        protected BaseCommand(IUnitOfWork uow)
        {
            if (uow == null)
                throw new ArgumentNullException("uow", "uow is null");

            _uow = uow;
        }

        protected IUnitOfWork UnitOfWork 
        { 
            get { return _uow; } 
        }

        public async virtual Task<TResult> Execute(TArguments arguments)
        {
            var validateResult = await Validate(arguments);

            if (validateResult.IsSuccess)
                return await PerformCommand(arguments);

            return validateResult;
        }

        /// <summary>В данном методе должна происходить вся валидация и 
        /// различные проверки передвыполнением</summary>
        protected abstract Task<TResult> Validate(TArguments arguments);

        /// <summary>Данный метод отвечает за выполнение команды</summary>
        protected abstract Task<TResult> PerformCommand(TArguments arguments);
    }
}
