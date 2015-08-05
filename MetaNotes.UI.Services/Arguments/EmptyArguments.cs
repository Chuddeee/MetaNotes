namespace MetaNotes.UI.Services
{
    /// <summary>Пустые аргументы для модел билдера (когда не нужны аргументы)</summary>
    public sealed class EmptyArguments : IModelBuilderArguments
    {
        private static readonly EmptyArguments _instance = new EmptyArguments();

        public static EmptyArguments DefaultInstance
        {
            get { return _instance; }
        }
    }
}
