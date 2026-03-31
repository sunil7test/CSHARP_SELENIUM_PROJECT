using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_SELENIUM_UTILITY_LAYER.LoggerUtility
{
    public interface ILogger
    {
        void Info(string message);
        void Debug(string message);
        void Error(string message, Exception ex = null);
        void Warn(string message);
    }
}
