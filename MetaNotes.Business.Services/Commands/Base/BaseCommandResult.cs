namespace MetaNotes.Business.Services
{
    public abstract class BaseCommandResult : ICommandResult
    {
        public virtual bool IsSuccess { get; set; }

        public virtual string ErrorMessage { get; set; }
    }
}
