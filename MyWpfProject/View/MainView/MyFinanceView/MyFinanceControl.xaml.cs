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

            foreach (Purpose purpose in purposes)
                AddPurposeShowInfoButton(purpose);          
        }
        private void AddPurposeShowInfoButton(Purpose purpose)
        {
            Button btt = new Button();
            btt.Content = purpose.Title;
            btt.Margin = new Thickness(5);
            btt.Click += (s, e) => { mainContentControl.Content = new PurposeInfoControl(purpose); };

            mainStackPanel.Children.Add(btt);
        }

        private void AddPurpose(object sender, RoutedEventArgs e)
        {
            if (AddPurposeWindow.IsOpenWindow == false)
            {
                int countPurpose = purposes.Count;

                AddPurposeWindow addPurposeWindow = new AddPurposeWindow(purposes);
                addPurposeWindow.Show();

                addPurposeWindow.Closed += (s, a) => 
                {
                    if (countPurpose != purposes.Count)
                        AddPurposeShowInfoButton(purposes.Last());
                };
            }
        }
    }
}
