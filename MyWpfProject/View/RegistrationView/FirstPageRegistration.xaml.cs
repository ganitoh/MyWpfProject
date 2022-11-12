using MyWpfProject.model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;


namespace MyWpfProject.View.RegistrationView
{
    public partial class FirstPageRegistration : Page
    {
        public FirstPageRegistration()
        {
            InitializeComponent();
        }
        private void TransitionSecondPageRegistration(object sender, RoutedEventArgs e)
        {
            if (IsEmptyLinesOfFirstRegistratioPage())
            {
                User user = new User()
                {
                    Name = nameTextBox.Text,
                    Surname = surnameTextBox.Text,
                    Age = int.Parse(ageTextBox.Text),
                };

                NavigationService.Navigate(new SecondPageRegistration(user));
            }
        }
        private bool IsEmptyLinesOfFirstRegistratioPage()
        {
            if (IsEmptyLine(nameTextBox.Text))
            {
                nameTextBox.ToolTip = "пустая строка";
                nameTextBox.Background = Brushes.DarkRed;
                return false;
            }
            else if (IsEmptyLine(surnameTextBox.Text))
            {
                surnameTextBox.ToolTip = "пустая строка";
                surnameTextBox.Background = Brushes.DarkRed;

                nameTextBox.ToolTip = "";
                nameTextBox.Background = Brushes.Transparent;

                return false;
            }
            else if (IsEmptyLine(ageTextBox.Text))
            {
                ageTextBox.ToolTip = "пустая строка";
                ageTextBox.Background = Brushes.DarkRed;

                nameTextBox.ToolTip = "";
                nameTextBox.Background = Brushes.Transparent;
                surnameTextBox.ToolTip = "";
                surnameTextBox.Background = Brushes.Transparent;

                return false;
            }
            else
            {
                return true;
            }
        }
        private bool IsEmptyLine(string str)
        {
            if (str.Length == 0)
                return true;
            else
                return false;
        }
    }
}
