using MyWpfProject.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyWpfProject.View.MainView.MyFinanceView
{
    public partial class PurposeInfoControl : UserControl
    {
        private Purpose purpose;
        public PurposeInfoControl(Purpose purpose)
        {
            this.purpose = purpose;
            InitializeComponent();
            purposeProgressBar.Value = GetPercentOfFinalamount();

            ProgressFinalAmount();
            
            
        }
         async private void ProgressFinalAmount()
         {
            await Task.Delay(1000);
            percentString.Text = $"{purpose.CollectedAmountMony}/{purpose.FinalAmountMony}";
         }
        private int GetPercentOfFinalamount() => purpose.CollectedAmountMony * 100 / purpose.FinalAmountMony;
    }
}
