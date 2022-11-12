using MyWpfProject.model;
using System;
using System.Data.SqlClient;
using System.Windows;

namespace MyWpfProject.View.MainView.ToDoListView
{
    public partial class EditMyTaskWindow : Window
    {

        MyTask myTask;
        public EditMyTaskWindow(MyTask myTask)
        {
            InitializeComponent();
            this.myTask = myTask;

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
        private bool IsChangedFields()
        {
            return titleTextBox.Text == myTask.Title && descriptionTextBox.Text == myTask.Description && deadLine.SelectedDate == myTask.Deadline;
        }
    }
}
