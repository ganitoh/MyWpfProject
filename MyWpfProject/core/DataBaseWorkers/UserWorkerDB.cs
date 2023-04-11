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
    internal class UserWorkerDB : IWorkerDB<User>
    {
        private readonly IDataBase dataBase;
        private User user;
        public UserWorkerDB(User user)
        {
            this.dataBase = new DB();
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
        public bool InsertRequest()
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
        public bool UpdateRequest()
        {
            dataBase.OpenConnection();

            SqlCommand updateCommand = new SqlCommand(
                $"UPDATE Users SET _name=N'{user.Name}',_surname=N'{user.Surname}',age=N'{user.Age}',email=N'{user.Email}',_login=N'{user.Login}',_password=N'{user.Password}' WHERE id=N'{user.ID}'", dataBase.Connection);

            if (updateCommand.ExecuteNonQuery() > 0)
                return true;
      
            else
                return false;
        }
        public bool DeleteRequest()
        {
            throw new NotImplementedException();
        }
    }
}
