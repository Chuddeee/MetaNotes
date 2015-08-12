using MetaNotes.Services;
using System;
using System.Collections.Generic;

namespace MetaNotes.Models
{
    public class LogsIndexModel
    {
        public IEnumerable<LogMessage> Messages { get; set; }

        public DateTime Date { get; set; }

        /// <summary>Конвертирует тип сообщения в css класс</summary>
        public string TypeToClassConverter(LogMessageType? type)
        {
            if (!type.HasValue)
                return string.Empty;

            switch (type)
            {
                case LogMessageType.Warn:
                    return "warning";

                case LogMessageType.Error:
                case LogMessageType.Fatal:
                    return "danger";

                default:
                    return string.Empty;
            }
        }
    }
}