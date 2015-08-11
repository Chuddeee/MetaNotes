using NLog;
using System;

namespace MetaNotes.Infrastructure.Logger
{
    public class NlogLogger : MetaNotes.Services.ILogger
    {
        private static readonly ILogger _logger = LogManager.GetLogger("");

        public void Trace(string message, Exception ex = null)
        {
            if (ex != null)
            {
                _logger.Trace(message, ex);
                return;
            }

            _logger.Trace(message);
        }

        public void Debug(string message, Exception ex = null)
        {
            if (ex != null)
            {
                _logger.Debug(message, ex);
                return;
            }

            _logger.Debug(message);
        }

        public void Info(string message, Exception ex = null)
        {
            if (ex != null)
            {
                _logger.Info(message, ex);
                return;
            }

            _logger.Info(message);
        }

        public void Warn(string message, Exception ex = null)
        {
            if (ex != null)
            {
                _logger.Warn(message, ex);
                return;
            }

            _logger.Warn(message);
        }

        public void Error(string message, Exception ex = null)
        {
            if (ex != null)
            {
                _logger.Error(message, ex);
                return;
            }

            _logger.Error(message);
        }

        public void Fatal(string message, Exception ex = null)
        {
            if (ex != null)
            {
                _logger.Fatal(message, ex);
                return;
            }

            _logger.Fatal(message);
        }
    }
}
