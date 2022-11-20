using MyWpfProject.model;
using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

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

                DB dataBase = new DB();
                dataBase.OpenConnection();

                SqlCommand updateCommand = new SqlCommand($"SET LANGUAGE russian UPDATE MyTasks SET title=N'{myTask.Title}', _description=N'{myTask.Description}', deadline=N'{myTask.Deadline}' WHERE id = N'{myTask.ID}'  ", dataBase.Connection);
                if (updateCommand.ExecuteNonQuery() > 0)
                    MessageBox.Show("данные изменины");

                dataBase.CloseConnection();

                this.Close();
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
