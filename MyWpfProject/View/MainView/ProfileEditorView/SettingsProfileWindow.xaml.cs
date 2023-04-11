using MyWpfProject.core.model;
using MyWpfProject.core.abstraction;
using System;
using System.Windows;
using System.Windows.Input;
using MyWpfProject.core.DataBaseWorkers;

namespace MyWpfProject.View.MainView.ProfileEditorView
{
    public partial class SettingsProfileWindow : Window
    {
        public static bool WindowOpen { get; set; }
        private User user;
        public static SettingsProfileWindow SettingsProfileWin { get; set; }
        public SettingsProfileWindow(User user)
        {
            this.user = user;
            SettingsProfileWin = this;    
            
            InitializeComponent();
            SetValueUserInfoToFields();
        }

        private void SetValueUserInfoToFields()
        {
            nameTextBox.Text = user.Name;
            surnameTextBox.Text = user.Surname;
            ageTextBox.Text = Convert.ToString(user.Age);
            emailTextBox.Text = user.Email;
            loginTextBox.Text = user.Login;
        }     
        private void EditProfileInfoButtonClick(object sender, RoutedEventArgs e)
        {
            if (IsChangedFields())
            {
                User updateUser = new User(user.ID,nameTextBox.Text,surnameTextBox.Text,Convert.ToInt32(ageTextBox.Text),emailTextBox.Text,loginTextBox.Text,user.Password);
                IWorkerDB<User> userWorkerDB = new UserWorkerDB(updateUser);

                if (userWorkerDB.UpdateRequest())
                {
                    user.UpdateInfoToUser(updateUser);
                    MessageBox.Show("данные изменены");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ошибка");
                }
            }
            else
                MessageBox.Show("измените данные");
        }
        private bool IsChangedFields()
        {
            return !(nameTextBox.Text == user.Name && surnameTextBox.Text == user.Surname && ageTextBox.Text == Convert.ToString(user.Age) && emailTextBox.Text == user.Email && loginTextBox.Text == user.Login);
        }
        private void ChangePassword(object sender, RoutedEventArgs e)
        {
            if (!ChangePasswordWindow.WindowOpen)
            {
                ChangePasswordWindow.WindowOpen = true;

                ChangePasswordWindow editPassword = new ChangePasswordWindow(user);
                editPassword.Show();

                editPassword.Closed += (s, a) => { ChangePasswordWindow.WindowOpen = false; };
            }


        }
        private void Drag(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                SettingsProfileWin.DragMove();
        }
        private void CollapseWindow(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;
        private void CloseWindow(object sender, RoutedEventArgs e) => this.Close();
    }
}
