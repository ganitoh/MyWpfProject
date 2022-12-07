using MyWpfProject.model;
using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;

namespace MyWpfProject.View.MainView.ProfileEditorView
{

    public partial class SettingsProfileWindow : Window
    {
        public static bool WindowOpen { get; set; }
        private User user;
        public static SettingsProfileWindow SettingsProfile { get; set; }
        public SettingsProfileWindow(User user)
        {
            InitializeComponent();
            this.user = user;
            SettingsProfile = this;            

            nameTextBox.Text = user.Name;
            surnameTextBox.Text = user.Surname;
            ageTextBox.Text = Convert.ToString(user.Age);
            emailTextBox.Text = user.Email;
            loginTextBox.Text = user.Login;
        }

        
        private void EditProfileInfoButtonClick(object sender, RoutedEventArgs e)
        {
            if (IsChangedFields())
                MessageBox.Show("измените данные");
            else
            {
                EditInfo();
                MessageBox.Show("данные изменены");
                this.Close();
            }
        }
        private void EditInfo()
        {
            if (nameTextBox.Text != user.Name)
            {
                UpdateSQLReques<string>(nameTextBox.Text, "_name", user.ID);
                user.Name = nameTextBox.Text;

            }
            if (surnameTextBox.Text != user.Surname)
            {
                UpdateSQLReques<string>(surnameTextBox.Text, "_surname", user.ID);
                user.Surname = surnameTextBox.Text;

            }
            if (ageTextBox.Text != Convert.ToString(user.Age))
            {
                int age = 0;
                if (int.TryParse(ageTextBox.Text, out age))
                {
                    UpdateSQLReques<int>(age, "age", user.ID);
                    user.Age = Convert.ToInt32(ageTextBox.Text);

                }
                else
                {
                    ageTextBox.ToolTip = "неверный фрмат";
                    ageTextBox.Background = Brushes.Red;
                }
            }
            if (emailTextBox.Text != user.Email)
            {
                UpdateSQLReques<string>(emailTextBox.Text, "email", user.ID);
                user.Email = emailTextBox.Text;

            }
            if (loginTextBox.Text != user.Login)
            {
                UpdateSQLReques<string>(nameTextBox.Text, "_login", user.ID);
                user.Login = loginTextBox.Text;

            }
        }
        private bool IsChangedFields()
        {
            return (nameTextBox.Text == user.Name && surnameTextBox.Text == user.Surname && ageTextBox.Text == Convert.ToString(user.Age) && emailTextBox.Text == user.Email && loginTextBox.Text == user.Login);
        }
        private void UpdateSQLReques<T>(T value, string columnName, int id)
        {
            DB dataBase = new DB();
            dataBase.OpenConnection();

            SqlCommand updateCommand = new SqlCommand($"UPDATE Users SET {columnName}=N'{value}' WHERE id=N'{id}'", dataBase.Connection);
            updateCommand.ExecuteNonQuery();

            dataBase.CloseConnection();
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
                SettingsProfile.DragMove();
        }
        private void CollapseWindow(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;
        private void CloseWindow(object sender, RoutedEventArgs e) => this.Close();
    }
}
