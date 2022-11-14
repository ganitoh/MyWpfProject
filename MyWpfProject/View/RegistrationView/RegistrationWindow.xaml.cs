using System.Windows;

namespace MyWpfProject.View.RegistrationView
{
    public partial class RegistrationWindow : Window
    {
        private RegistrationWindow regWindow;
        public RegistrationWindow()
        {
            InitializeComponent();

            mainFrame.Content = new FirstPageRegistration();
        }
    }
}
