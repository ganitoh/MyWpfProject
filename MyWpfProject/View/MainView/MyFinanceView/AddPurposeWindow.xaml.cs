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
using System.Windows.Shapes;

namespace MyWpfProject.View.MainView.MyFinanceView
{
    public partial class AddPurposeWindow : Window
    {
        public static bool IsOpenWindow { get; set; } = false;
        public AddPurposeWindow()
        {
            InitializeComponent();

            IsOpenWindow = true;
            this.Closed += (s,e) => { IsOpenWindow = false; };
        }

        private void AddPurpose(object sender, RoutedEventArgs e)
        {

        }
    }
}
