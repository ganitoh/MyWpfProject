using MyWpfProject.intarfaces;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace MyWpfProject.model
{
    public class DB : IDataBase
    {
        private readonly SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDataBase"].ConnectionString);

        public SqlConnection Connection
        {
            get { return _connection; }
        }

        public void OpenConnection()
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
                _connection.Open();
        }

        public void CloseConnection()
        {
            if (_connection != null || _connection.State != ConnectionState.Closed)
                _connection.Close();

        }
    }
}
