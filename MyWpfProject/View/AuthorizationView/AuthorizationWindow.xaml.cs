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
            InitializeComponent();
            _AuthorizationWindow = this;
            AnimationButton();
        }

        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                AuthorizationWindow._AuthorizationWindow.DragMove();
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
                    MainWindow meinWindow = new MainWindow(GetUserFromDataBase(textBoxLogin.Text, passwordBox.Password));
                    meinWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("пароль иди логин введены неверно");
                    passwordBox.Clear();
                }

                db.CloseConnection();
            }
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
                    if (reader.GetName(0) == "id")
                        user.ID = reader.GetInt32(0);
                    if (reader.GetName(1) == "_name")
                        user.Name = reader.GetString(1);
                    if (reader.GetName(2) == "_surname")
                        user.Surname = reader.GetString(2);
                    if (reader.GetName(3) == "age")
                        user.Age = reader.GetInt32(3);
                    if (reader.GetName(4) == "email")
                        user.Email = reader.GetString(4);
                    if (reader.GetName(5) == "_login")
                        user.Login = reader.GetString(5);
                    if (reader.GetName(6) == "_password")
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
