using MyWpfProject.model;
using System;
using System.Windows.Controls;

namespace MyWpfProject.View.MainView.ProfileView
{
    public partial class MyTaskControl : UserControl
    {
        public MyTaskControl(MyTask myTask)
        {
            InitializeComponent();

            titleTextBlock.Text = myTask.Title;
            dateCreateTextBlock.Text = myTask.DateCreate.ToShortDateString();
            deadlineTextBlock.Text = myTask.Deadline.ToShortDateString();
        }
    }
}
