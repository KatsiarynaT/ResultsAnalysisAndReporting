using log4net.Config;
using System;

namespace SeleniumWebDriverBasics.Utilities.Logs
{
    public static class LoggerManager
    {
        static LoggerManager()
        {
            XmlConfigurator.Configure(new FileInfo("Log.config"));
        }

        public static Logger GetLogger(Type type)
        {
            return new Logger(type);
        }
    }
}