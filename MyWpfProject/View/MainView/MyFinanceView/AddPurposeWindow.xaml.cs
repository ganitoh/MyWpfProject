using MyWpfProject.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Runtime.InteropServices;

namespace MyWpfProject.View.MainView.MyFinanceView
{
    public partial class AddPurposeWindow : Window
    {
        public static bool IsOpenWindow { get; set; } = false;
        public AddPurposeWindow PurposeWindow { get; set; }
        public AddPurposeWindow()
        {
            InitializeComponent();

            PurposeWindow = this;

            IsOpenWindow = true;
            this.Closed += (s,e) => { IsOpenWindow = false; };
        }



        private void AddPurpose(object sender, RoutedEventArgs e)
        {

            if (IsAllFieldsCorrect())
            {
                Purpose purpose = new Purpose()
                {
                    Title = titleTextBox.Text,
                    Discription = discriptionTextBox.Text,
                    FinalAmountMony = Convert.ToInt32(finalAmountMonyTextBox.Text),
                    CollectedAmountMony = Convert.ToInt32(collectedAmountMonyTextBox.Text)
                };

                DB dataBase = new DB();
                dataBase.OpenConnection();

                SqlCommand insertCommand = new SqlCommand(
                    $"INSERT INTO Purposes (title,_discription,finalAmountMony,collectedAmountMony)" +
                    $" VALUES (N'{purpose.Title}',N'{purpose.Discription}',N'{purpose.FinalAmountMony}',N'{purpose.CollectedAmountMony}')", dataBase.Connection);
                insertCommand.ExecuteNonQuery();

                this.Close();
            }
        }

        private bool IsAllFieldsCorrect()
        {
            int countError = 0;

            foreach (TextBox textBox in mainStackPanel.Children.OfType<TextBox>())
            {
                if (IsEmptyLine(textBox.Text))
                {
                    textBox.ToolTip = "неверный формат";
                    textBox.Background = Brushes.DarkRed;
                    countError++;
                }
            }

            if (!IsCorrectAmount(finalAmountMonyTextBox.Text))
            {
                finalAmountMonyTextBox.ToolTip = "неверный формат";
                finalAmountMonyTextBox.Background = Brushes.DarkRed;
                countError++;
            }
            else if (!IsCorrectAmount(collectedAmountMonyTextBox.Text))
            {
                collectedAmountMonyTextBox.ToolTip = "неверный формат";
                collectedAmountMonyTextBox.Background = Brushes.DarkRed;
                countError++;
            }

            return countError == 0;
        }
        private bool IsCorrectAmount(string finalAmountMonyText)
        {
            try
            {
                int result = Convert.ToInt32(finalAmountMonyText);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private bool IsEmptyLine(string str)
        {
            if (str.Length == 0)
                return true;
            else
                return false;
        }
        private void CollapseWindow(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Minimized;
            else
                this.WindowState-= WindowState.Normal;
        }
        private void CloseWindow(object sender, RoutedEventArgs e) => this.Close();
        private void Drag(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                PurposeWindow.DragMove();         
        }
    }
}
