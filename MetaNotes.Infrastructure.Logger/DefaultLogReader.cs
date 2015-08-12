using MetaNotes.Services;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MetaNotes.Infrastructure.Logger
{
    public class DefaultLogReader : ILogReader
    {
        private readonly ILogMessageParser _parser;
        //признак окончания сообщения
        private const string lineEnd = "~=~LineEnd~=~";

        public DefaultLogReader(ILogMessageParser parser)
        {
            _parser = parser;
        }

        public IEnumerable<LogMessage> ReadLogs(string fileName)
        {
            var result = new List<LogMessage>();

            bool isMultiline = false; //является ли текущее сообщение многострочным
            StringBuilder builder = new StringBuilder();

            // читаем файл полностью, чтобы не держать его долго открытым
            // если файл может быть большим, то лучше читать его построчно
            using (var file = File.OpenText(fileName))
            {
                string fileLine;
                
                while((fileLine = file.ReadLine()) != null)
                {
                    if(fileLine.Contains(lineEnd))
                    {
                        var messageStr = fileLine.Replace(lineEnd, string.Empty);

                        if(isMultiline)
                        {
                            builder.Append(messageStr);
                            messageStr = builder.ToString();
                            isMultiline = false;
                            builder.Clear();
                        }

                        var message = new LogMessage();
                        if (_parser.TryParse(messageStr, out message))
                        {
                            yield return message;
                        }
                    }
                    else 
                    {
                        isMultiline = true;
                        builder.Append(fileLine);
                    }
                }               
            }
        }
    }
}
