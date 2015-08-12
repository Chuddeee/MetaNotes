namespace MetaNotes.Services
{
    /// <summary>Парсер для сообщения логгирования</summary>
    public interface ILogMessageParser
    {
        /// <summary>Пытается распарсить сообщение логгирования. 
        /// Возвращает тру если распарсить удалось, иначе фолс</summary>
        bool TryParse(string str, out LogMessage message);
    }
}
