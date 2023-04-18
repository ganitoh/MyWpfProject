using System.Threading.Tasks;
using System.IO;

namespace MyWpfProject.logger
{
    internal class WriteLog : IWriteLog
    {
        private const string path = @"C:\Users\vadik\OneDrive\Рабочий стол\log.txt";
        async public Task WriteAsync(string logMessage)
        {
            using (StreamWriter writer = new StreamWriter(path,true))
                await writer.WriteLineAsync(logMessage);
        }
    }
}
