using MyWpfProject.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public partial class MyFinanceControl : UserControl
    {
        private List<Purpose> purposes;
        public MyFinanceControl(List<Purpose> purposes)
        {
            InitializeComponent();

            this.purposes = purposes;

            PurposeInfoControl purposeInfoControl = new PurposeInfoControl();
            purposeInfoControl.Height = 400;
            purposeInfoControl.Width = 600;
            leftColumn.Children.Add(purposeInfoControl);

            PurposeInfoControl purposeInfoControl1 = new PurposeInfoControl();
            purposeInfoControl1.Height = 400;
            purposeInfoControl1.Width = 600;
            rightColumn.Children.Add(purposeInfoControl1);
        }

        private void AddPurpose(object sender, RoutedEventArgs e)
        {         
            if (AddPurposeWindow.IsOpenWindow == false)
            {
                AddPurposeWindow addPurposeWindow = new AddPurposeWindow();
                addPurposeWindow.Show();
            }
        }
    }
}
