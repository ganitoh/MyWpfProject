using MyWpfProject.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace MyWpfProject.View.MainView.MyFinanceView
{
    public partial class PurposeInfoControl : UserControl
    {
        private ContentControl contentControl;
        private Purpose purpose;
        private string finalExpression;
        private int countNum;
        public PurposeInfoControl(Purpose purpose, ContentControl contentControl)
        {
            this.purpose = purpose;
            this.contentControl = contentControl;

            InitializeComponent();
            purposeProgressBar.Value = GetPercentOfFinalAmount();
            titileTextBlock.Text = purpose.Title;
            discriptionPurposeTextBlock.Text = purpose.Discription;

            ProgressFinalAmount();
        }
        async private void ProgressFinalAmount()
         {
            await Task.Delay(1000);
            percentTextBlock.Text = $"{purpose.CollectedAmountMony}/{purpose.FinalAmountMony}";
         }
        private int GetPercentOfFinalAmount() => purpose.CollectedAmountMony * 100 / purpose.FinalAmountMony;
        private void AddMonyToProgressButton(object sender, RoutedEventArgs e)
        {
            purpose.CollectedAmountMony += GetAmountMony();
            purposeProgressBar.Value = GetPercentOfFinalAmount();
            percentTextBlock.Text = $"{purpose.CollectedAmountMony}/{purpose.FinalAmountMony}";

            DB dataBase = new DB();
            dataBase.OpenConnection();

            SqlCommand updateCommand = new SqlCommand($"UPDATE Purposes SET collectedAmountMony=N'{purpose.CollectedAmountMony}' WHERE id=N'{purpose.ID}'",dataBase.Connection);
            updateCommand.ExecuteNonQuery();

            dataBase.CloseConnection();
            valueMonyTextBox.Clear();
        }
        private int GetAmountMony()
        {
            try
            {
                return Convert.ToInt32(valueMonyTextBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("неверный формат");
                return 0;
            }
        }
        private void Clear(object sender, RoutedEventArgs e) => valueTextBlock.Text = "0";
        private void NineNum(object sender, RoutedEventArgs e)
        {
            if (valueTextBlock.Text == "0")
                valueTextBlock.Text = "9";
            else
                valueTextBlock.Text += "9";
        }
        private void EightNum(object sender, RoutedEventArgs e)
        {
            if (valueTextBlock.Text == "0")
                valueTextBlock.Text = "8";
            else
                valueTextBlock.Text += "8";
        }
        private void SevenNum(object sender, RoutedEventArgs e)
        {
            if (valueTextBlock.Text == "0")
                valueTextBlock.Text = "7";
            else
                valueTextBlock.Text += "7";
        }
        private void SixNum(object sender, RoutedEventArgs e)
        {
            if (valueTextBlock.Text == "0")
                valueTextBlock.Text = "6";
            else
                valueTextBlock.Text += "6";
        }
        private void FiveNum(object sender, RoutedEventArgs e)
        {
            if (valueTextBlock.Text == "0")
                valueTextBlock.Text = "5";
            else
                valueTextBlock.Text += "5";
        }
        private void FourNum(object sender, RoutedEventArgs e)
        {
            if (valueTextBlock.Text == "0")
                valueTextBlock.Text = "4";
            else
                valueTextBlock.Text += "4";
        }
        private void ThreeNum(object sender, RoutedEventArgs e)
        {
            if (valueTextBlock.Text == "0")
                valueTextBlock.Text = "3";
            else
                valueTextBlock.Text += "3";
        }
        private void TwoNum(object sender, RoutedEventArgs e)
        {
            if (valueTextBlock.Text == "0")
                valueTextBlock.Text = "2";
            else
                valueTextBlock.Text += "2";
        }
        private void OneNum(object sender, RoutedEventArgs e)
        {
            if (valueTextBlock.Text == "0")
                valueTextBlock.Text = "1";
            else
                valueTextBlock.Text += "1";
        }
        private void ZeroNum(object sender, RoutedEventArgs e)
        {
            if (valueTextBlock.Text == "0")
                valueTextBlock.Text = "0";
            else
                valueTextBlock.Text += "0";
        }
        private void SumNum(object sender, RoutedEventArgs e)
        {
            finalExpression += valueTextBlock.Text;
            finalExpression += '+';
        }
        private void ResultNums(object sender, RoutedEventArgs e)
        {
            Regex resultExpression = new Regex(@"(\d*)\+(\d)");
            Match resultMatch = resultExpression.Match(finalExpression);

            if (resultMatch.Success)
            {
                int result = Convert.ToInt32(resultMatch.Groups[1]);
            }
        }
    }
}
