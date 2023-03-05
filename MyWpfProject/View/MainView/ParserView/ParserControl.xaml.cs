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
using MyWpfProject.View.MainView.ParserView.controls;
using MyWpfProject.View.MainView.ParserView.core;

namespace MyWpfProject.View.MainView.ParserView
{
    partial class ParserControl : UserControl
    {
        private ParserWorker<string[]> parser;
        private List<string[]> headersParses = new List<string[]>();
        public ParserControl()
        {
            parser = new ParserWorker<string[]>(new HabraParser());
            
            InitializeComponent();

            parser.OnComplited += ParserOnComplited;
            parser.OnNewData += ParserOnNewData;

            startPoint.Handler += StartPoint_Handler;
            endPoint.Handler += EndPoint_Handler;
        }

        private void EndPoint_Handler(string exceptionMessage) => MessageBox.Show(exceptionMessage);

        private void StartPoint_Handler(string exceptionMessage) => MessageBox.Show(exceptionMessage);

        private void ParserOnComplited(object obj)
        {
            MessageBox.Show("закончил работу");
        }
        private void ParserOnNewData(object arg1, string[] headers)
        {
            headersParserContentcontroll.Content = new PageHeadersControl(headers);
        }

        private void GoWorkParser(object sender, RoutedEventArgs e)
        {
            if (startPoint.Value <= endPoint.Value)
            {
                page.Text = startPoint.Value.ToString();
                parser.ParserSettings = new ParserSettings(startPoint.Value, endPoint.Value);
                parser.Start();
            }
            else
            {
                MessageBox.Show("начальная страница должна быть меньше или равна конечной");
            }
        }
    }
}
