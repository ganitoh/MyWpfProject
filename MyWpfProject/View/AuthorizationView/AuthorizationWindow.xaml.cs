using MyWpfProject.model;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using MyWpfProject.View.RegistrationView;

namespace MyWpfProject.View.AuthorizationView
{
    public partial class AuthorizationWindow : Window
    {
        public static AuthorizationWindow _AuthorizationWindow { get; set; }
        public AuthorizationWindow()
        {
            bool authorization = Properties.Settings.Default.authorization;

            if (authorization)
            {
                User user = new User
                {
                    ID = Properties.Settings.Default.id,
                    Name = Properties.Settings.Default.name,
                    Surname = Properties.Settings.Default.surname,
                    Email = Properties.Settings.Default.email,
                    Login = Properties.Settings.Default.login,
                    Password = Properties.Settings.Default.password,
                    Age= Properties.Settings.Default.age,
                };

                MainWindow mainWindow = new MainWindow(user);
                mainWindow.Show();
                this.Close();

            }
            else
            {
                InitializeComponent();
                _AuthorizationWindow = this;
                AnimationButton();
            }
        }

        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                _AuthorizationWindow.DragMove();
            }
        }
        private void AnimationButton()
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 350;
            doubleAnimation.Duration = TimeSpan.FromSeconds(1);

            authorizationButton.BeginAnimation(WidthProperty, doubleAnimation);
        }
        private void RegistrationClickButton(object sender, RoutedEventArgs e)
        {
            RegistrationWindow reg = new RegistrationWindow();
            reg.Show();

            this.Close();
        }
        private void AuthorizationUsersButton(object sender, RoutedEventArgs e)
        {
            if (IsEmptyLinesAunhorizationWindows())
            {
                DB db = new DB();
                db.OpenConnection();

                DataTable sqlRequestSelect = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Users WHERE _login=N'{textBoxLogin.Text}' AND _password=N'{passwordBox.Password}'", db.Connection);
                adapter.Fill(sqlRequestSelect);

                if (sqlRequestSelect.Rows.Count > 0)
                {
                    User user = GetUserFromDataBase(textBoxLogin.Text, passwordBox.Password);

                    SetUserIfoToconfig(user);

                    MainWindow mainWindow = new MainWindow(user);
                    mainWindow.Show();
                    this.Close();


                    Properties.Settings.Default.authorization = true;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    MessageBox.Show("пароль или логин введены неверно");
                    passwordBox.Clear();
                }

                db.CloseConnection();
            }
        }
        private void SetUserIfoToconfig(User user)
        {
            Properties.Settings.Default.id = user.ID;
            Properties.Settings.Default.name = user.Name;
            Properties.Settings.Default.surname = user.Surname;
            Properties.Settings.Default.age = user.Age;
            Properties.Settings.Default.email = user.Email;
            Properties.Settings.Default.login = user.Login;
            Properties.Settings.Default.password = user.Password;
        }
        private bool IsEmptyLinesAunhorizationWindows()
        {
            if (IsEmptyLine(textBoxLogin.Text))
            {
                textBoxLogin.ToolTip = "неверный формат";
                textBoxLogin.Background = Brushes.DarkRed;

                return false;
            }
            else if (IsEmptyLine(passwordBox.Password))
            {
                passwordBox.ToolTip = "неверный формат";
                passwordBox.Background = Brushes.DarkRed;
                return false;
            }
            else
                return true;

        }
        private User GetUserFromDataBase(string login, string password)
        {
            DB db = new DB();
            db.OpenConnection();

            SqlCommand command = new SqlCommand($"SELECT * FROM Users WHERE _login=N'{login}' AND _password=N'{password}'", db.Connection);
            SqlDataReader reader = null;
            User user = new User();

            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {  
                    user.ID = reader.GetInt32(0);
                    user.Name = reader.GetString(1);
                    user.Surname = reader.GetString(2);
                    user.Age = reader.GetInt32(3);
                    user.Email = reader.GetString(4);
                    user.Login = reader.GetString(5);
                    user.Password = reader.GetString(6);
                }
                return user;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                db.CloseConnection();
            }
        }
        private bool IsEmptyLine(string str)
        {
            if (str.Length == 0)
                return true;
            else
                return false;
        }
        private void CloseWindow(object sender, RoutedEventArgs e) => this.Close();
        private void CollapseWindow(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;
    }


}
