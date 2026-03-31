using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using log4net;

namespace CORE_SELENIUM_UTILITY_LAYER.LoggerUtility
{
    public class LoggerWrapper: ILogger
    {
        
        private readonly ILog _logger;

        public LoggerWrapper()
        {
            _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void Info(string message) => _logger.Info(message);
        public void Debug(string message) => _logger.Debug(message);
        public void Error(string message, Exception ex = null) => _logger.Error(message, ex);
        public void Warn(string message) => _logger.Warn(message);
    }
}
