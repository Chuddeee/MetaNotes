using System;

namespace MetaNotes.Business.Services
{
    /// <summary>Интерфейс для работы с директориями</summary>
    public interface IDirectoryManager
    {
        /// <summary>Возвращает путь к базовой директории приложения</summary>
        string GetBaseDirectory();

        /// <summary>Возвращает путь к папке AppData</summary>
        /// <returns></returns>
        string GetAppDataDirectory();

        /// <summary>Возвращает путь к корневой папке с логами</summary>
        string GetLogsRootDirectory();

        /// <summary>Возвращает путь к папке с логами за определенную дату</summary>
        string GetLogsDirectory(DateTime date);
    }
}
