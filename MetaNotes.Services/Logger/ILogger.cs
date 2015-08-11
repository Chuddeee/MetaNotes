using System;

namespace MetaNotes.Services
{
    public interface ILogger
    {
        /// <summary>залоггировать сообщение трассировки</summary>
        void Trace(string message, Exception ex = null);

        /// <summary>залоггировать сообщение отладки</summary>
        void Debug(string message, Exception ex = null);

        /// <summary>залоггировать информационное сообщение</summary>
        void Info(string message, Exception ex = null);

        /// <summary>залоггировать сообщение о предупреждении</summary>
        void Warn(string message, Exception ex = null);

        /// <summary>залоггировать сообщение об ошибке</summary>
        void Error(string message, Exception ex = null);

        /// <summary>залоггировать сообщение о критической ошибке</summary>
        void Fatal(string message, Exception ex = null);
    }
}
