using MyWpfProject.model;
using MyWpfProject.View.AuthorizationView;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyWpfProject.View.RegistrationView
{
    public partial class SecondPageRegistration : Page
    {
        User user = new User();
        public SecondPageRegistration(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void AddUserToDataBase(object sender, RoutedEventArgs e)
        {
            if (IsAllLinesCorrectAndShowNotificationtoTheUsers())
            {
                if (IsLoginUniqueCheck())
                {
                    user.Email = emailTextBox.Text;
                    user.Login = loginTextBox.Text;
                    user.Password = passwordBox.Password;

                    DB db = new DB();
                    db.OpenConnection();

                    SqlCommand insertCommand = new SqlCommand($"insert into Users (_name,_surname,age,email,_login,_password) values (N'{user.Name}',N'{user.Surname}',N'{user.Age}',N'{user.Email}',N'{user.Login}',N'{user.Password}')", db.Connection);
                    if (insertCommand.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("вы успешно зарегистрировались", "регистрация", MessageBoxButton.OK, MessageBoxImage.Information);

                        AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                        authorizationWindow.Show();

                        Window.GetWindow(this).Close();
                    }
                    else
                        MessageBox.Show("произошла ошибка");
                }
                else
                    MessageBox.Show(" логин уже занят");
            }
        }
        private bool IsLoginUniqueCheck()
        {
            DB dataBase = new DB();
            dataBase.OpenConnection();

            DataTable table = new DataTable();
            SqlDataAdapter selectAdapter = new SqlDataAdapter($"SELECT * FROM Users WHERE _login=N'{loginTextBox.Text}' ", dataBase.Connection);

            selectAdapter.Fill(table);

            if (table.Rows.Count > 0)
                return false;

            else
                return true;
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
