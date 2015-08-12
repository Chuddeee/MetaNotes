using MetaNotes.Business.Services;
using MetaNotes.Models;
using MetaNotes.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace MetaNotes.ModelBuilders
{
    public class LogsIndexModelBuilder
    {
        private readonly IFileManager _fileManager;
        private readonly ILogReader _logReader;

        public LogsIndexModelBuilder(IFileManager fileManager, ILogReader logReader)
        {
            _fileManager = fileManager;
            _logReader = logReader;
        }

        public LogsIndexModel Build(DateTime date)
        {
            var model = new LogsIndexModel() { Messages = new List<LogMessage>() };
            model.Date = date;
            var fileName = _fileManager.GetLogFilePath(date);
            var isExists = File.Exists(fileName);

            if (!isExists)
                return model;

            var messages = _logReader.ReadLogs(fileName);
            var list = new List<LogMessage>();
            foreach(var message in messages)
            {
                list.Add(message);
            }

            model.Messages = messages;
            return model;
        }
    }
}