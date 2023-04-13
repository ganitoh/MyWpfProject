using MyWpfProject.core.model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MyWpfProject.View.MainView.ToDoListView
{
    public partial class ToDoListControl : UserControl
    {
        private List<MyTask> myTasks;
        public ToDoListControl(List<MyTask> myTasks)
        {
            this.myTasks = myTasks ?? new List<MyTask>();

            InitializeComponent();

            foreach (MyTask myTask in this.myTasks)
                tasksStackPanel.Children.Add(new MyTaskControl(myTask, tasksStackPanel, myTasks));
        }
        private void AddMyTask(object sender, RoutedEventArgs e)
        {
            CreateMyTaskWindow createMyTaskWindow = new CreateMyTaskWindow(myTasks);
            createMyTaskWindow.Show();

            int countMyTask = myTasks.Count;

            createMyTaskWindow.Closed += (s, a) =>
            {
                if (countMyTask != myTasks.Count)
                    tasksStackPanel.Children.Add(new MyTaskControl(myTasks.Last(), tasksStackPanel, myTasks));
            };
        }
    }
}
