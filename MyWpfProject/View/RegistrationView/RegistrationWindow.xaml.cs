using System.Windows;

namespace MyWpfProject.View.RegistrationView
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();

            mainFrame.Content = new FirstPageRegistration();
        }
    }
}
