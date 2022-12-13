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
            
            if (myTask.Title.Length > 10)
            {
                string abbreviatedTitle = "";
                for (int i = 0; i <= 10; i++)
                    abbreviatedTitle += myTask.Title[i];

                abbreviatedTitle += "...";

                titleTextBlock.Text = abbreviatedTitle;
                dateCreateTextBlock.Text = myTask.DateCreate.ToShortDateString();
                deadlineTextBlock.Text = myTask.Deadline.ToShortDateString();
            }
            else
            {
                titleTextBlock.Text = myTask.Title;
                dateCreateTextBlock.Text = myTask.DateCreate.ToShortDateString();
                deadlineTextBlock.Text = myTask.Deadline.ToShortDateString();
            }
        }
    }
}
