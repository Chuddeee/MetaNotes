using MetaNotes.Common;
using MetaNotes.Services;
using System;
using System.Text.RegularExpressions;

namespace MetaNotes.Infrastructure.Logger
{
    public class DefaultLogParser : ILogMessageParser
    {
        //минимальная длина части сообщения, включающая [ ]
        private const int partMinLength = 3;
        //разделитель частей сообщений
        private const string partsSeparator = "~~";
        //паттерн лог сообщения
        private const string msgPattern = @"^\[.+\]~~\[.+\]~~\[.+\]$";

        public bool TryParse(string str, out LogMessage message)
        {
            message = new LogMessage();
            var result = false;

            if (str.IsNullOrWhiteSpace())
                return result;

            var regex = new Regex(msgPattern);
            if (!regex.IsMatch(str))
                return result;

            var matches = str.Split(new string[] { partsSeparator }, StringSplitOptions.RemoveEmptyEntries);

            //парсинг типа сообщения
            if (matches.Length > 0)
            {
                var content = GetContent(matches[0]);
                message.Type = ParseType(content);
            }

            //парсинг даты
            if (matches.Length > 1)
            {
                var content = GetContent(matches[1]);
                message.Date = ParseDate(content);
            }

            //парсинг сообщения
            if (matches.Length > 2)
            {
                var content = GetContent(matches[2]);
                message.Message = content;
            }

            result = message.Type.HasValue || message.Date.HasValue || !message.Message.IsNullOrWhiteSpace();
            return result;
        }
     
        //парсит тип сообщения
        private LogMessageType? ParseType(string type)
        {
            LogMessageType? result = null;
            LogMessageType outRes;

            if (Enum.TryParse<LogMessageType>(type, true, out outRes))
            {
                result = outRes;
            }

            return result;
        }

        //парсит дату
        private DateTime? ParseDate(string date)
        {
            DateTime? result = null;
            DateTime outDate;

            if(DateTime.TryParse(date,out outDate))
            {
                result = outDate;
            }

            return result;
        }

        //получает контент части сообщения
        private string GetContent(string str)
        {
            if (str.Length >= partMinLength)
            {
                return str.Substring(1, str.Length - 2);
            }

            return null;
        }
    }
}
