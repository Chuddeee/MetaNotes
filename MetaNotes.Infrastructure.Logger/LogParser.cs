using MetaNotes.Common;
using MetaNotes.Services;
using System;
using System.Text.RegularExpressions;

namespace MetaNotes.Infrastructure.Logger
{
    public class LogParser : ILogParser
    {
        private const string matchRegex = @"\[.+\]";
        private const int matchMinLength = 3;

        public bool TryParse(string str, out LogMessage message)
        {
            message = null;
            var result = false;

            if (str.IsNullOrWhiteSpace())
                return result;

            var matches = Regex.Split(str, matchRegex);


            //парсинг типа сообщения
            if (matches.Length > 0)
            {
                message = new LogMessage();
                var typeMatch = matches[0];

                if (typeMatch.Length >= matchMinLength)
                {
                    var typeStr = typeMatch.Substring(0, typeMatch.Length - (matchMinLength - 1));
                    message.Type = ParseType(typeStr);
                }
            }

            //парсинг даты
            if (matches.Length > 1)
            {
                var dateMatch = matches[1];

                if (dateMatch.Length >= matchMinLength)
                {
                    var typeStr = dateMatch.Substring(0, dateMatch.Length - (matchMinLength - 1));
                    message.Date = ParseDate(typeStr);
                }
            }

            //парсинг сообщения
            if(matches.Length > 2)
            {
                message.Message = matches[2];
            }

            return result;
        }

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

    }
}
