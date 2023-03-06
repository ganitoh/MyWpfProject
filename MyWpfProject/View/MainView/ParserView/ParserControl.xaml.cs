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
        private List<string>[] headersParses;
        private int pageValue = 0;

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

        private void ParserOnNewData(object arg1, string[] headers)
        {

            headersParses[pageValue] = headers.ToList(); 
            pageValue++;
        }
        private void ParserOnComplited(object obj)
        {
            pageTextBlock.Text = "1";
            headersParserContentcontroll.Content = new PageHeadersControl(headersParses[0]);
            pageValue = 1;
        }

        private void GoWorkParser(object sender, RoutedEventArgs e)
        {
            if (startPoint.Value <= endPoint.Value)
            {
                headersParses = new List<string>[endPoint.Value];

                parser.ParserSettings = new ParserSettings(startPoint.Value, endPoint.Value);
                parser.Start();
            }
            else
            {
                MessageBox.Show("начальная страница должна быть меньше или равна конечной");
            }
        }

        private void NextPage(object sender, RoutedEventArgs e)
        {
            if (pageValue < headersParses.Length)
            {
                pageValue++;
                headersParserContentcontroll.Content = new PageHeadersControl(headersParses[pageValue-1]);
                pageTextBlock.Text = $"{Convert.ToInt32(pageTextBlock.Text) + 1}";
            }
        }

        private void PreviousPage(object sender, RoutedEventArgs e)
        {
            if (pageValue > 0)
            {
                pageValue--;
                headersParserContentcontroll.Content = new PageHeadersControl(headersParses[pageValue-1]);
                pageTextBlock.Text = $"{Convert.ToInt32(pageTextBlock.Text) - 1}";
            }
        }
    }
}
