using MyWpfProject.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
                MessageBox.Show("не верный формат");
                return 0;
            }
        }
    }
}
