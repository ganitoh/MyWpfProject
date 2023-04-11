using MyWpfProject.core.model;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;

namespace MyWpfProject.View.MainView.ProfileEditorView
{
    public partial class ChangePasswordWindow : Window
    {
        private User user;
        public static bool WindowOpen { get; set; } = false;
        public static ChangePasswordWindow ChangePassword { get; set; }
        public ChangePasswordWindow(User user)
        {
            InitializeComponent();
            this.user = user;
            ChangePassword = this;
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
        private void Drag(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                ChangePassword.DragMove();
        }

        private void CollapseWindow(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;
        private void CloseWindow(object sender, RoutedEventArgs e) => this.Close();
    }
}
