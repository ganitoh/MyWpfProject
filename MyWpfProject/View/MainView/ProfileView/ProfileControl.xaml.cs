using MyWpfProject.model;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace MyWpfProject.View.MainView.ProfileView
{
    public partial class ProfileControl : UserControl
    {
        public ProfileControl(User user, List<MyTask> myTasks)
        {
            InitializeComponent();
            AddInfoProfile(user);
            AddMyTask(myTasks);
        }
        private void AddInfoProfile(User user)
        {
            photoContantControll.Content = new ButtonAddPhotoControl(user);

            fullNameTextBlok.Text = $" {user.Name} {user.Surname} {Convert.ToString(user.Age)} лет ";

            if (user.ProfilePhotoFilePath != null)
                photoContantControll.Content = new UserPhotoControl(user.ProfilePhotoFilePath);
        }
        private void AddMyTask(List<MyTask> myTasks)
        {
            foreach (MyTask myTask in myTasks)
                MyTasksStackPanel.Children.Add(new MyTaskControl(myTask));
        }
    }
}
