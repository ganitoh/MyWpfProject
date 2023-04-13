using MyWpfProject.core.model;
using MyWpfProject.core.abstraction;
using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using MyWpfProject.core.DataBaseWorkers;

namespace MyWpfProject.View.MainView.ToDoListView
{
    public partial class EditMyTaskWindow : Window
    {
        public static EditMyTaskWindow EditMyTaskW { get; set; }
        MyTask myTask;
        public EditMyTaskWindow(MyTask myTask)
        {
            InitializeComponent();
            this.myTask = myTask;
            EditMyTaskW = this;

            titleTextBox.Text = myTask.Title;
            descriptionTextBox.Text = myTask.Description;
            deadLine.SelectedDate = myTask.Deadline;
        }

        private void EditMyTask(object sender, RoutedEventArgs e)
        {
            if (IsChangedFields())
            {
                MessageBox.Show("измените данные");
            }
            else
            {
                myTask.Title = titleTextBox.Text;
                myTask.Description = descriptionTextBox.Text;
                myTask.Deadline = (DateTime)deadLine.SelectedDate;

                IUpdateSQlRequest<MyTask> updateRequest = new MyTaskWorkerDB();
                updateRequest.Id = myTask.ID;
                if (updateRequest.UpdateRequest(myTask))
                {
                    MessageBox.Show("данные изменины");
                    this.Close();
                }
            }
        }
        private bool IsChangedFields() => titleTextBox.Text == myTask.Title && descriptionTextBox.Text == myTask.Description && deadLine.SelectedDate == myTask.Deadline;

        private void CollapseWindow(object sender, RoutedEventArgs e) => WindowState = WindowState.Maximized ;

        private void CloseWindow(object sender, RoutedEventArgs e) => this.Close();

        private void Darg(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(Mouse.LeftButton == MouseButtonState.Pressed) 
            {
                EditMyTaskW.DragMove();
            }
        }
    }
}
