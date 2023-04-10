using MyWpfProject.intarfaces;
using MyWpfProject.model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace MyWpfProject.View.AuthorizationView.core
{
    internal class UserWorkerDB : IWorkerDB<User>
    {
        private readonly IDataBase dataBase;
        private User user;
        public UserWorkerDB(IDataBase db, User user)
        {
            this.dataBase = db;
            this.user = user;
        }

        public User SelectRequest()
        {
            dataBase.OpenConnection();

            DataTable sqlRequestSelect = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Users WHERE _login=N'{user.Login}' AND _password=N'{user.Password}'", dataBase.Connection);
            adapter.Fill(sqlRequestSelect);

            dataBase.CloseConnection();

            if (sqlRequestSelect.Rows.Count > 0)
                return GetUserFromDataBase(user.Login, user.Password);
            else
               return null;
        }

        private User GetUserFromDataBase(string login, string password)
        {
            dataBase.OpenConnection();

            SqlCommand command = new SqlCommand($"SELECT * FROM Users WHERE _login=N'{login}' AND _password=N'{password}'", dataBase.Connection);
            SqlDataReader reader = null;
            User user = new User();

            try
            {
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
                return user;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                dataBase.CloseConnection();
            }
        }
        public void DeleteRequest()
        {
            throw new NotImplementedException();
        }

        public void InsertRequest()
        {
            throw new NotImplementedException();
        }


        public User UpdateRequest()
        {
            throw new NotImplementedException();
        }
    }
}
