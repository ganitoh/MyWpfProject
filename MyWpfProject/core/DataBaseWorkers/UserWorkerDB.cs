using MyWpfProject.core.model;
using MyWpfProject.core.abstraction;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyWpfProject.core.DataBaseWorkers
{
    internal class UserWorkerDB : ISelectSqlRequest<User>,IIinsertSqlRequest<User>,IUpdateSQlRequest<User>
    {
        private readonly IDataBase dataBase;
        private string loginUser, passwordUser;
        private int userId;

        public int Id
        {
            get
            {
                return userId;
            }
            set
            {
                if (value >= 0)
                    userId = value;
                else
                    IdNotCorrectError?.Invoke(this, "идентификатор не может быть меньше 0");
            }
        }

        event Action<object, string> IdNotCorrectError;
        
        public UserWorkerDB(string loginUser, string passwordUser)
        {
            dataBase = new DB();
            this.loginUser = loginUser;
            this.passwordUser = passwordUser;
        }
        public UserWorkerDB()
        {
            dataBase = new DB();
        }

        public User SelectRequest()
        {
            dataBase.OpenConnection();

            DataTable sqlRequestSelect = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Users WHERE _login=N'{loginUser}' AND _password=N'{passwordUser}'", dataBase.Connection);
            adapter.Fill(sqlRequestSelect);

            dataBase.CloseConnection();

            if (sqlRequestSelect.Rows.Count > 0)
                return GetUserFromDataBase();
            else
                return null;
        }
        private User GetUserFromDataBase()
        {
            dataBase.OpenConnection();

            SqlDataReader reader = null;
            User user = new User();

            try
            {
                ReaderWork(user,reader);
                return user;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                dataBase.CloseConnection();
            }
        }
        private void ReaderWork(User user,SqlDataReader reader)
        {
            SqlCommand command = new SqlCommand($"SELECT * FROM Users WHERE _login=N'{loginUser}' AND _password=N'{passwordUser}'", dataBase.Connection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                user.ID = reader.GetInt32(0);
                user.Name = reader.GetString(1);
                user.Surname = reader.GetString(2);
                user.Age = reader.GetInt32(3);
                user.Email = reader.GetString(4);
                user.Login = reader.GetString(5);
                user.Password = reader.GetString(6);
            }
        }
        public bool InsertRequest(User user)
        {
            dataBase.OpenConnection();
            SqlCommand insertCommand = new SqlCommand($"insert into Users (_name,_surname,age,email,_login,_password) values (N'{user.Name}',N'{user.Surname}',N'{user.Age}',N'{user.Email}',N'{user.Login}',N'{user.Password}')", dataBase.Connection);      

            try
            {
                insertCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateRequest(User user)
        {
            dataBase.OpenConnection();

            SqlCommand updateCommand = new SqlCommand(
                $"UPDATE Users SET _name=N'{user.Name}',_surname=N'{user.Surname}',age=N'{user.Age}',email=N'{user.Email}',_login=N'{user.Login}',_password=N'{user.Password}' WHERE id=N'{userId}'", dataBase.Connection);

            if (updateCommand.ExecuteNonQuery() > 0)
                return true;
      
            else
                return false;
        }
    }
}
