using MyWpfProject.core.model;
using MyWpfProject.core.abstraction;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;
using MyWpfProject.core.DataBaseWorkers;

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

            IIinsertSqlRequest<MyTask> insertRequest = new MyTaskWorkerDB();

            if (insertRequest.InsertRequest(myTask))
            {
                myTasks.Add(myTask);
                this.Close();
            }
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
