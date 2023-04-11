using MyWpfProject.core.model;
using MyWpfProject.core.abstraction;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;


namespace MyWpfProject.View.MainView.MyFinanceView
{
    public partial class PurposeInfoControl : UserControl
    {
        private ContentControl contentControl;
        private Purpose purpose;
        private string finalExpression;
        public PurposeInfoControl(Purpose purpose, ContentControl contentControl)
        {
            this.purpose = purpose;
            this.contentControl = contentControl;

            InitializeComponent();

            ShowInfoThisPurposes();
            BindCalculatorButtonActions();
        }

        private void ShowInfoThisPurposes()
        {
            purposeProgressBar.Value = GetPercentOfFinalAmount();
            titileTextBlock.Text = purpose.Title;
            discriptionPurposeTextBlock.Text = purpose.Discription;
            amountLeftTextBlock.Text = $"осталась сумма: {purpose.GetRemainingAmountMony()}";

            ProgressFinalAmount();
        }
        private void BindCalculatorButtonActions()
        {
            foreach (UIElement item in calcGrid.Children)
            {
                if (item is Button)
                {
                    ((Button)item).Click += Calculate;
                }
            }
        }
        private void Calculate(object sender, RoutedEventArgs e)
        {
            string newSymbolWithPressedBtt = (string)((Button)e.OriginalSource).Content;

            if (newSymbolWithPressedBtt == "C")
            {
                valueTextBlock.FontSize = 35;
                finalExpression = "";
                valueTextBlock.Text = "0";
            }
            else if (newSymbolWithPressedBtt == "=")
            {
                string result = new DataTable().Compute(finalExpression,null).ToString();

                if (result.Length > 12) 
                {
                    valueTextBlock.FontSize = 25;
                    valueTextBlock.Text = result;
                    finalExpression = result;
                }
                else
                {
                    valueTextBlock.Text = result;
                    finalExpression = result;
                }
                
            }
            else if (newSymbolWithPressedBtt == "<")
            {
                string lastSymbol = valueTextBlock.Text[valueTextBlock.Text.Length-1].ToString();
                string resultValueString = finalExpression.Replace(lastSymbol,"");
                
                valueTextBlock.Text = resultValueString;
                finalExpression = resultValueString;
            }
            else
            {
                WriteInExpressionNewSymbol(newSymbolWithPressedBtt);
            }
        }
        private void WriteInExpressionNewSymbol(string newSymbol)
        {
            if (valueTextBlock.Text != "0")
            {
                finalExpression += newSymbol;
                valueTextBlock.Text += newSymbol;
            }
            else
            {
                valueTextBlock.Text = "";
                finalExpression += newSymbol;
                valueTextBlock.Text += newSymbol;
            }
        }
        async private void ProgressFinalAmount()
        {
            await Task.Delay(1000);
            percentTextBlock.Text = $"{purpose.CollectedAmountMoney}/{purpose.FinalAmountMoney}";
        }
        private int GetPercentOfFinalAmount() => Convert.ToInt32(purpose.CollectedAmountMoney * 100 / purpose.FinalAmountMoney);
        private void AddMonyToProgressButton(object sender, RoutedEventArgs e)
        {
            purpose.CollectedAmountMoney += GetAmountMony();
            purposeProgressBar.Value = GetPercentOfFinalAmount();
            percentTextBlock.Text = $"{purpose.CollectedAmountMoney}/{purpose.FinalAmountMoney}";

            DB dataBase = new DB();
            dataBase.OpenConnection();

            SqlCommand updateCommand = new SqlCommand($"UPDATE Purposes SET collectedAmountMoney=N'{purpose.CollectedAmountMoney}' WHERE id=N'{purpose.ID}'",dataBase.Connection);
            updateCommand.ExecuteNonQuery();

            dataBase.CloseConnection();
            valueMonyTextBox.Clear();

            amountLeftTextBlock.Text = $"осталась сумма: {purpose.GetRemainingAmountMony()}";
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
 
    }
}
