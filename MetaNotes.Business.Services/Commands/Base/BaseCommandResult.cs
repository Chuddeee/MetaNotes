namespace MetaNotes.Business.Services
{
    public abstract class BaseCommandResult : ICommandResult
    {
        public virtual bool IsSuccess { get; set; }

        public virtual string ErrorMessage { get; set; }

        public virtual void AddError(string error)
        {
            IsSuccess = false;
            ErrorMessage = error;
        }
    }
}
