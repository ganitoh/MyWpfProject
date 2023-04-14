using System;

namespace MyWpfProject.logger
{
    internal abstract class Logger<T>
    {
        protected IWriteLog writeLog;
        protected string currentTime;
        protected string _namespace;
        public Logger(IWriteLog writeLog)
        {
            this.writeLog = writeLog;
            currentTime = $"{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}";
            _namespace = typeof(T).FullName;
        }
        public abstract void Log(string message,LogLevel level,Exception ex = null);
        protected abstract string CreateLogMessage(string message,LogLevel level,Exception ex = null);
    }
}
