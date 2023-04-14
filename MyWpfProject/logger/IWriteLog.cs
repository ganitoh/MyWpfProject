using System.Threading.Tasks;

namespace MyWpfProject.logger
{
    internal interface IWriteLog
    {
          Task WriteAsync(string log);
    }
}
