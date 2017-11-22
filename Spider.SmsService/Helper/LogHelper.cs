using log4net;

namespace Spider.SmsService.Helper
{
    public class LogHelper
    {
        public static void Debug(string message)
        {
            ILog log = LogManager.GetLogger("LogOut");
            if (log.IsDebugEnabled)
            {
                log.Debug(message);
            }
            log = null;
        }

        public static void Error(string message)
        {
            ILog log = LogManager.GetLogger("LogOut");
            if (log.IsErrorEnabled)
            {
                log.Error(message);
            }
            log = null;
        }

        public static void Fatal(string message)
        {
            ILog log = LogManager.GetLogger("LogOut");
            if (log.IsFatalEnabled)
            {
                log.Fatal(message);
            }
            log = null;
        }

        public static void Info(string message)
        {
            ILog log = LogManager.GetLogger("LogOut");
            if (log.IsInfoEnabled)
            {
                log.Info(message);
            }
            log = null;
        }

        public static void Warn(string message)
        {
            ILog log = LogManager.GetLogger("LogOut");
            if (log.IsWarnEnabled)
            {
                log.Warn(message);
            }
            log = null;
        }
    }
}