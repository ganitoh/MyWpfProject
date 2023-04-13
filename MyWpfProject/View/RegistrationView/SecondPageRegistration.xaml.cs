using MyWpfProject.core.model;
using MyWpfProject.core.abstraction;
using MyWpfProject.View.AuthorizationView;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MyWpfProject.core.DataBaseWorkers;

namespace MyWpfProject.View.RegistrationView
{
    public partial class SecondPageRegistration : Page
    {
        User user = new User();
        public SecondPageRegistration(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void AddUserToDataBase(object sender, RoutedEventArgs e)
        {
            if (IsAllLinesCorrectAndShowNotificationtoTheUsers())
            {
                user.Email = emailTextBox.Text;
                user.Login = loginTextBox.Text;
                user.Password = passwordBox.Password;

                IIinsertSqlRequest<User> insertRequest = new UserWorkerDB();

                if (insertRequest.InsertRequest(user))
                {
                    MessageBox.Show("вы успешно зарегистрировались", "регистрация", MessageBoxButton.OK, MessageBoxImage.Information);

                    AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                    authorizationWindow.Show();

                    Window.GetWindow(this).Close();
                }
                else
                {
                    MessageBox.Show("логин уже занят");
                }
            }
        }
        private bool IsAllLinesCorrectAndShowNotificationtoTheUsers()
        {
            if (IsEmptyLine(emailTextBox.Text) || !emailTextBox.Text.Contains("@") || !emailTextBox.Text.Contains("."))
            {
                emailTextBox.ToolTip = "пустая строка";
                emailTextBox.Background = Brushes.DarkRed;
                return false;
            }
            else if (IsEmptyLine(loginTextBox.Text))
            {
                loginTextBox.ToolTip = "пустая строка";
                loginTextBox.Background = Brushes.DarkRed;
                return false;
            }
            else if (IsEmptyLine(passwordBox.Password) || IsEmptyLine(repeadPasswordBox.Password))
            {
                passwordBox.ToolTip = "пустые строки пароля";
                repeadPasswordBox.ToolTip = "пустые строки пароля";
                passwordBox.Background = Brushes.DarkRed;
                repeadPasswordBox.Background = Brushes.DarkRed;
                return false;
            }
            else if (!IsPassworMatch(passwordBox.Password, repeadPasswordBox.Password))
            {
                passwordBox.ToolTip = "пароли не совпадают";
                repeadPasswordBox.ToolTip = "пароли не совпадают";
                passwordBox.Background = Brushes.DarkRed;
                repeadPasswordBox.Background = Brushes.DarkRed;
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool IsEmptyLine(string str)
        {
            if (str.Length == 0)
                return true;
            else
                return false;
        }
        private bool IsPassworMatch(string pass, string pass2)
        {
            if (pass == pass2)
                return true;
            else
                return false;
        }
    }
}
