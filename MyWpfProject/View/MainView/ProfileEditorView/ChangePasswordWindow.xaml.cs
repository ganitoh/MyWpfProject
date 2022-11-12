using MyWpfProject.model;
using System.Windows;
using System.Windows.Media;

namespace MyWpfProject.View.MainView.ProfileEditorView
{
    public partial class ChangePasswordWindow : Window
    {
        private User user;
        public ChangePasswordWindow(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void CheckoutPassword(object sender, RoutedEventArgs e)
        {
            string enteredPassword = passwordBox.Password;

            if (enteredPassword == user.Password)
                editPasswordContatntControll.Content = new ChangePasswordControl(user);
            else
            {
                passwordBox.Background = Brushes.Red;
                passwordBox.ToolTip = "неверный пароль";
            }
        }
    }
}
