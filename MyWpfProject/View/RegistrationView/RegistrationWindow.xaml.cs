
using System.Windows;
using System.Windows.Input;

namespace MyWpfProject.View.RegistrationView
{
    public partial class RegistrationWindow : Window
    {
        public static RegistrationWindow RegWindow { get; set; }

        public RegistrationWindow()
        {
            InitializeComponent();

            RegWindow = this;
            mainFrame.Content = new FirstPageRegistration();
        }

        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)          
                RegWindow.DragMove();       
        }
        private void CloseWindow(object sender, RoutedEventArgs e) => this.Close();
        private void CollapseWindow(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;
    }
}
