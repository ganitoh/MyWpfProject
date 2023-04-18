using MyWpfProject.core.abstraction;
using MyWpfProject.core.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace MyWpfProject.core.DataBaseWorkers
{
    internal class MyTaskWorkerDB : ISelectSqlRequest<List<MyTask>>,IIinsertSqlRequest<MyTask>,IUpdateSQlRequest<MyTask>,IDeleteSqlRequest<int> 
    {
        private IDataBase dataBase;
        private int userId;

        public int Id
        {
            get { return userId; }
            set 
            {
                if (value >= 0)
                    userId = value;
                else
                    IdNotCorrectError?.Invoke(this, "идентификатор не может быть меньше 0");
            }
        }

        public event Action<object, string> IdNotCorrectError;

        public MyTaskWorkerDB(int userId)
        {
            this.userId = userId;
            dataBase = new DB();
        }
        public MyTaskWorkerDB()
        {
            dataBase = new DB();
        }

        public List<MyTask> SelectRequest()
        {
            dataBase.OpenConnection();

            DataTable myTasksTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM MyTasks where userId={userId}", dataBase.Connection);
            adapter.Fill(myTasksTable);

            if (myTasksTable.Rows.Count>0)
                return GetMyTasks();
            else
                return null;
        }
        private List<MyTask> GetMyTasks()
        {
            List<MyTask> myTasks = new List<MyTask>();
            SqlDataReader reader = null;

            try
            {
                ReaderWork(myTasks, reader);
                return myTasks;
            }
            catch (Exception )
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
        private void ReaderWork(List<MyTask> myTasks,SqlDataReader reader)
        {
            SqlCommand command = new SqlCommand($" SELECT * FROM MyTasks where userId={userId} ", dataBase.Connection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                MyTask myTask = new MyTask();

                myTask.ID = reader.GetInt32(0);
                myTask.UserId = reader.GetInt32(1);
                myTask.Title = reader.GetString(2);
                myTask.Description = reader.GetString(3);
                myTask.DateCreate = reader.GetDateTime(4);
                myTask.Deadline = reader.GetDateTime(5);

                myTasks.Add(myTask);
            }
        }
        public bool InsertRequest(MyTask myTask)
        {
            dataBase.OpenConnection();

            SqlCommand insertCommand = new SqlCommand($"SET LANGUAGE russian INSERT INTO MyTasks (userId,title,_description,dateCreate,deadline) VALUES (N'{myTask.UserId}',N'{myTask.Title}',N'{myTask.Description}','{myTask.DateCreate}','{myTask.Deadline}')", dataBase.Connection);
            if (insertCommand.ExecuteNonQuery() > 0)
            {
                dataBase.CloseConnection();

                //id к элементу добаляется только в самой базе данных, и для того что бы достать id используем метод GetIdMyTask(dataBase)
                myTask.ID = GetIdMyTask();

                return true;
            }
            else
            {
                dataBase.CloseConnection();
                return false;
            }


        }
        private int GetIdMyTask()
        {
            dataBase.OpenConnection();
            SqlCommand command = new SqlCommand("SELECT * FROM MyTasks ORDER BY id DESC ", dataBase.Connection);
            SqlDataReader reader = null;

            try
            {
                reader = command.ExecuteReader();

                if (reader.Read())
                    return (int)reader["id"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                dataBase.CloseConnection();
            }
            return 0;
        }
        public bool UpdateRequest(MyTask myTask)
        {
            dataBase.OpenConnection();

            SqlCommand updateCommand = new SqlCommand($"SET LANGUAGE russian UPDATE MyTasks SET title=N'{myTask.Title}', _description=N'{myTask.Description}', deadline=N'{myTask.Deadline}' WHERE id = N'{myTask.ID}'  ", dataBase.Connection);
            if (updateCommand.ExecuteNonQuery() > 0)
            {
                dataBase.CloseConnection();
                return true;
            }
            else
            {
                dataBase.CloseConnection();
                return false;
            }
        }

        public bool DeleteRequest(int id)
        {
            dataBase.OpenConnection();

            SqlCommand deleteCommand = new SqlCommand($"DELETE FROM MyTasks WHERE id=N'{id}'", dataBase.Connection);

            if (deleteCommand.ExecuteNonQuery() > 0)
            {
                dataBase.CloseConnection();
                return true;
            }
            else
            {
                dataBase.CloseConnection();
                return false;
            }
        }
    }
}
