using MyWpfProject.core.model;
using MyWpfProject.core.abstraction;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace MyWpfProject.View.MainView.ToDoListView
{
    public partial class CreateMyTaskWindow : Window
    {
        public CreateMyTaskWindow CreateTaskW { get; set; }
        private List<MyTask> myTasks;

        public CreateMyTaskWindow(List<MyTask> myTasks)
        {
            InitializeComponent();
            this.myTasks = myTasks;
            CreateTaskW = this;
        }
        private void AddMyTask(object sender, RoutedEventArgs e)
        {
            int userId = Properties.Settings.Default.id;
            MyTask myTask = new MyTask(userId,(DateTime)deadLine.SelectedDate, descriptionTextBox.Text, titleTextBox.Text);

            DB dataBase = new DB();
            dataBase.OpenConnection();

            SqlCommand command = new SqlCommand($"SET LANGUAGE russian INSERT INTO MyTasks (userId,title,_description,dateCreate,deadline) VALUES (N'{myTask.UserId}',N'{myTask.Title}',N'{myTask.Description}','{myTask.DateCreate}','{myTask.Deadline}')", dataBase.Connection);
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

        private void Drag(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                CreateTaskW.DragMove();
        }

        private void CollapseWindow(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        private void CloseWindow(object sender, RoutedEventArgs e) => this.Close();
    }
}
