using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
        private int pageValue;
        private bool isActiveHeadersSearch = false;

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
            isActiveHeadersSearch = false;
            if (startPoint.Value <= endPoint.Value)
            {
                pageValue = 0;

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
            if (pageValue < headersParses.Length && !isActiveHeadersSearch)
            {
                pageValue++;
                headersParserContentcontroll.Content = new PageHeadersControl(headersParses[pageValue-1]);
                pageTextBlock.Text = $"{Convert.ToInt32(pageTextBlock.Text) + 1}";
            }
        }

        private void PreviousPage(object sender, RoutedEventArgs e)
        {
            if (pageValue > 1 && !isActiveHeadersSearch)
            {
                pageValue--;
                headersParserContentcontroll.Content = new PageHeadersControl(headersParses[pageValue-1]);
                pageTextBlock.Text = $"{Convert.ToInt32(pageTextBlock.Text) - 1}";
            }
        }

        private void SearchHeasrs(object sender, RoutedEventArgs e)
        {
            isActiveHeadersSearch = true;
            List<string> searchHeaders = new List<string>();
            
            foreach (var pageHeaders in headersParses )
            {
                foreach (var header in pageHeaders)
                {
                    char[] symbolSeprator = { ' ', ',', ';', ':', '!', '?', '.', '/','"', '@','#','№','$','%','&','(',')','<','>','"'};
                    string[] words = header.Split(symbolSeprator);

                    for (int i = 0; i < words.Length; i++)
                    {
                        if (words[i] == searchHeadersTextBox.Text)
                        {
                            searchHeaders.Add(header);
                        }
                    }
                }
            }

            headersParserContentcontroll.Content = new PageHeadersControl(searchHeaders);
        }

        private void ResetSearch(object sender, RoutedEventArgs e)
        {
            isActiveHeadersSearch = false;
            pageTextBlock.Text = "1";
            headersParserContentcontroll.Content = new PageHeadersControl(headersParses[0]);
            pageValue = 1;
        }
    }
}
