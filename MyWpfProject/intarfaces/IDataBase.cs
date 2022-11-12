using System.Data.SqlClient;

namespace MyWpfProject.intarfaces
{
    internal interface IDataBase
    {
        SqlConnection Connection { get; }
        void OpenConnection();
        void CloseConnection();

    }
}
