using MetaNotes.Services;
using System.Collections.Generic;
using System.IO;

namespace MetaNotes.Infrastructure.Logger
{
    public class LogReader : ILogReader
    {
        private readonly ILogParser _parser;

        public LogReader(ILogParser parser)
        {
            _parser = parser;
        }

        public IEnumerable<LogMessage> ReadLogs(string fileName)
        {
            // Читаем файл построчно
            using (var file = File.OpenText(fileName))
            {
                string line = null;
                while ((line = file.ReadLine()) != null)
                {
                    LogMessage message;
                    if (_parser.TryParse(line, out message))
                    {
                        yield return message;
                    }
                }
            }
        }
    }
}
