using MyWpfProject.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace MyWpfProject.View.MainView.ToDoListView
{
    public partial class CreateMyTaskWindow : Window
    {
        private List<MyTask> myTasks;

        public CreateMyTaskWindow(List<MyTask> myTasks)
        {
            InitializeComponent();
            this.myTasks = myTasks;
        }
        private void AddMyTask(object sender, RoutedEventArgs e)
        {
            MyTask myTask = new MyTask((DateTime)deadLine.SelectedDate, descriptionTextBox.Text, titleTextBox.Text);

            DB dataBase = new DB();
            dataBase.OpenConnection();

            SqlCommand command = new SqlCommand($"SET LANGUAGE russian INSERT INTO MyTasks (title,_description,dateCreate,deadline) VALUES (N'{myTask.Title}',N'{myTask.Description}','{myTask.DateCreate}','{myTask.Deadline}')", dataBase.Connection);
            command.ExecuteNonQuery();

            //id к элементу добаляется только в самой базе данных, и для того что бы достать id используем метод GetIdMyTask(dataBase)
            myTask.ID = GetIdMyTask(dataBase);

            myTasks.Add(myTask);

            dataBase.CloseConnection();

            this.Close();
        }
        private int GetIdMyTask(DB dataBase)
        {
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
            }
            return 0;
        }
    }
}
