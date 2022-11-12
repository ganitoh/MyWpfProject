using MyWpfProject.model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace MyWpfProject.View.MainView.ToDoListView
{
    public partial class MyTaskControl : UserControl
    {
        private MyTask myTask;
        private StackPanel stackPanel;
        private List<MyTask> myTasks;
        public MyTaskControl(MyTask myTask, StackPanel stackPanel, List<MyTask> myTasks)
        {
            InitializeComponent();

            this.myTask = myTask;
            this.stackPanel = stackPanel;
            this.myTasks = myTasks;

            titleTextBlock.Text = myTask.Title;
            descriptionTextblock.Text = myTask.Description;
            createDateTextBlock.Text = myTask.DateCreate.ToShortDateString();
            deadlineTextBlock.Text = myTask.Deadline.ToShortDateString();
        }
        private void EditTaskButtonClick(object sender, RoutedEventArgs e)
        {
            EditMyTaskWindow editMyTasks = new EditMyTaskWindow(myTask);
            editMyTasks.Show();

            editMyTasks.Closed += (s, a) =>
            {
                titleTextBlock.Text = myTask.Title;
                descriptionTextblock.Text = myTask.Description;
                deadlineTextBlock.Text = myTask.Deadline.ToShortDateString();
            };
        }
        private void DeleteTaskButtonClick(object sender, RoutedEventArgs e)
        {
            DB dataBase = new DB();
            dataBase.OpenConnection();

            SqlCommand deleteCommand = new SqlCommand($"DELETE FROM MyTasks WHERE id=N'{myTask.ID}'", dataBase.Connection);
            if (deleteCommand.ExecuteNonQuery() > 0)
            {
                stackPanel.Children.Remove(this);
                myTasks.Remove(myTask);
            }

            dataBase.CloseConnection();
        }
    }
}
