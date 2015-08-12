using System;
using System.Collections.Generic;

namespace MetaNotes.Business.Services
{
    /// <summary>Менеджер для работы с файлами</summary>
    public interface IFileManager
    {
        /// <summary>Возвращет лог файл за определенную дату(последний актуальный файл)</summary>
        string GetLogFilePath(DateTime date);
    }
}
