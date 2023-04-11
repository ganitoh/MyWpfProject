using MyWpfProject.core.model;
using MyWpfProject.core.abstraction;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using MyWpfProject.View.RegistrationView;
using MyWpfProject.core.DataBaseWorkers;


namespace MyWpfProject.View.AuthorizationView
{
    public partial class AuthorizationWindow : Window
    {
        public static AuthorizationWindow _AuthorizationWindow { get; set; }
        private IWorkerDB<User> userWorkerDB;
        public AuthorizationWindow()
        {
            AuthorizationCheck();
        }

        private void AuthorizationCheck()
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
                    Age = Properties.Settings.Default.age,
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
                User checkUser = new User(textBoxLogin.Text, passwordBox.Password);
                UserIsCorrectAndAuthorization(new UserWorkerDB(checkUser));
            }
        }
        private void UserIsCorrectAndAuthorization(IWorkerDB<User> workerDB)
        {
            userWorkerDB = workerDB;

            User user = userWorkerDB.SelectRequest();

            if (!(user is null))
            {
                SetUserIfoToconfig(user);

                Properties.Settings.Default.authorization = true;
                Properties.Settings.Default.Save();

                MainWindow mainWindow = new MainWindow(user);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("пароль или логин введены неверно");
                passwordBox.Clear();

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
