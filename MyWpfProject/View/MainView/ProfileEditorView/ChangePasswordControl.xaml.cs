using MyWpfProject.core.model;
using MyWpfProject.core.abstraction;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MyWpfProject.core.DataBaseWorkers;

namespace MyWpfProject.View.MainView.ProfileEditorView
{
    public partial class ChangePasswordControl : UserControl
    {
        private User user;
        public ChangePasswordControl(User user)
        {
            this.user = user;
            InitializeComponent();
        }
        private void ChangePassword(object sender, RoutedEventArgs e)
        {
            string newPassword = passwordBox.Password;
            string repeatNewPassword = repeatPasswordBox.Password;

            if (newPassword != repeatNewPassword)
                ShowErrorPassword("пароли не совпадают");
            else if (newPassword == user.Password && repeatNewPassword == user.Password)
                ShowErrorPassword("придумайте новый пароль");
            else
            {
                user.Password = newPassword;

                IUpdateSQlRequest<User> updateRequest = new UserWorkerDB();
                updateRequest.Id = user.ID;

                if (updateRequest.UpdateRequest(user))
                {
                    MessageBox.Show("пароль изменен");
                    Window.GetWindow(this).Close();
                }
                else
                    MessageBox.Show("ошибка");
            }
                
        }
        private void ShowErrorPassword(string message)
        {
            passwordBox.ToolTip = $"{message}";
            passwordBox.Background = Brushes.Red;

            repeatPasswordBox.ToolTip = $"{message}";
            repeatPasswordBox.Background = Brushes.Red;
        }
    }
}
