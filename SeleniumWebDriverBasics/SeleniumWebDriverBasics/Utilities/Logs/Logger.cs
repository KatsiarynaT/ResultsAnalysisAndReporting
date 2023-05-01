using log4net;
using System;

namespace SeleniumWebDriverBasics.Utilities.Logs
{
    public class Logger
    {
        private readonly ILog log;

        internal Logger(Type type)
        {
            log = LogManager.GetLogger(type);
        }

        public void Info(string message)
        {
            log.Info(message);
        }

        public void Debug(string message)
        {
            log.Debug(message);
        }

        public void Error(string message)
        {
            log.Error(message);
        }
    }
}