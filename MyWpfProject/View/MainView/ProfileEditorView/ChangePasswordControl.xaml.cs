using MyWpfProject.core.model;
using MyWpfProject.core.abstraction;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace MyWpfProject.View.MainView.ProfileEditorView
{
    public partial class ChangePasswordControl : UserControl
    {
        User user;
        public ChangePasswordControl(User user)
        {
            InitializeComponent();

            this.user = user;
        }
        private void ChangePassword(object sender, RoutedEventArgs e)
        {
            string newPassword = passwordBox.Password;
            string repeatNewPassword = repeatPasswordBox.Password;

            if (newPassword == repeatNewPassword)
            {
                user.Password = newPassword;
                ChangePasswordInDataBase(newPassword);
            }
            else if (newPassword == user.Password && repeatNewPassword == user.Password)
            {
                passwordBox.ToolTip = "придумайте новый пароль";
                passwordBox.Background = Brushes.Red;

                repeatPasswordBox.ToolTip = "придумайте новый пароль";
                repeatPasswordBox.Background = Brushes.Red;
            }
            else
            {
                passwordBox.ToolTip = "пароли не совпадают";
                passwordBox.Background = Brushes.Red;

                repeatPasswordBox.ToolTip = "пароли не совпадают";
                repeatPasswordBox.Background = Brushes.Red;
            }
        }
        private void ChangePasswordInDataBase(string newPassword)
        {
            DB dataBase = new DB();
            dataBase.OpenConnection();

            SqlCommand updateCommand = new SqlCommand($"UPDATE Users SET _password=N'{newPassword}' WHERE id=N'{user.ID}' ", dataBase.Connection);
            updateCommand.ExecuteNonQuery();

            dataBase.CloseConnection();
            Window.GetWindow(this).Close();
        }
    }
}
