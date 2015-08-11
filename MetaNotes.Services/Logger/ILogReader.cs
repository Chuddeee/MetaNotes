using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaNotes.Services
{
    public interface ILogReader
    {
        IEnumerable<LogMessage> ReadLogs(string fileName);
    }
}
