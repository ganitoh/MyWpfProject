using System.Data.SqlClient;

namespace MyWpfProject.core.abstraction
{
    internal interface IDataBase
    {
        SqlConnection Connection { get; }
        void OpenConnection();
        void CloseConnection();

    }
}
