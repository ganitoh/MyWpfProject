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

namespace MyWpfProject.View.MainView.ParserView.controls
{
    partial class PageHeadersControl : UserControl
    {
        List<string> headers = new List<string>();
        public PageHeadersControl(string[] headers)
        {
            this.headers = headers.ToList<String>();
            InitializeComponent();

            foreach (string header in this.headers)
            {
                Button headerButton = new Button();
                headerButton.Content = header;



            }
        }
    }
}
