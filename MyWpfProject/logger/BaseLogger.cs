using System;

namespace MyWpfProject.logger
{
    internal class BaseLogger<T> : Logger<T>
    {
        public BaseLogger(IWriteLog writeLog) : base(writeLog)
        { 

        }
        public override void Log(string message,LogLevel level, Exception ex = null)
        {
            string logMessage = CreateLogMessage(message,level,ex);

            switch (level)
            {
                case LogLevel.LogInfo:
                   writeLog.WriteAsync(logMessage);
                    break;
                case LogLevel.LogWarning:
                    writeLog.WriteAsync(logMessage);
                    break;
                case LogLevel.LogError:
                    writeLog.WriteAsync(logMessage);
                    break;
            }
        }
        protected override string CreateLogMessage(string message, LogLevel Level, Exception ex = null)
        {
            if (ex is null)
                return $"message :{message} | status:{Level} | namespace: {_namespace} | time: {currentTime}";
            else
                return $"message :{message} | status:{Level} |error message: {ex.Message} | namespace: {_namespace} | time: {currentTime}";
        }
    }
}
