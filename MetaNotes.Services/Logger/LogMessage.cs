using System;
namespace MetaNotes.Services
{
    /// <summary>Сообщение логгера</summary>
    public class LogMessage
    {
        public LogMessageType? Type { get; set; }

        public string Message { get; set; }

        public DateTime? Date { get; set; }
    }
}
