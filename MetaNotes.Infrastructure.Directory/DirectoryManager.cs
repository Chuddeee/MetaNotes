using MetaNotes.Business.Services;
using System;
using System.IO;
using System.Web.Hosting;

namespace MetaNotes.Infrastructure.Directory
{
    public class DirectoryManager : IDirectoryManager
    {
        private const string _appDataFolderName = "App_Data";
        private const string _logsDirectoryName = "logs";
        private const string _logsDateFormat = "dd-MM-yyyy";

        public string GetBaseDirectory()
        {
            return HostingEnvironment.ApplicationPhysicalPath;
        }

        public string GetAppDataDirectory()
        {
            return Path.Combine(GetBaseDirectory(), _appDataFolderName);
        }

        public string GetLogsRootDirectory()
        {
            return Path.Combine(GetBaseDirectory(), _logsDirectoryName);
        }

        public string GetLogsDirectory(DateTime date)
        {
            var folderName = date.ToString(_logsDateFormat);
            return Path.Combine(GetLogsRootDirectory(), folderName);
        }
    }
}
