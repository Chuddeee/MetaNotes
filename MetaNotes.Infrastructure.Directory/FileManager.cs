using MetaNotes.Business.Services;
using System;
using System.IO;

namespace MetaNotes.Infrastructure.Directory
{
    public class FileManager : IFileManager
    {
        private readonly IDirectoryManager _directoryManager;
        private const string fileName = "logs.log";

        public FileManager(IDirectoryManager dirManager)
        {
            _directoryManager = dirManager;
        }

        public string GetLogFilePath(DateTime date)
        {
            var logsDir = _directoryManager.GetLogsDirectory(date);
            return Path.Combine(logsDir, fileName);
        }
    }
}
