using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MyWpfProject.View.MainView.ParserView.controls;
using MyWpfProject.View.MainView.ParserView.core;

namespace MyWpfProject.View.MainView.ParserView
{
    partial class ParserControl : UserControl
    {
        private ParserWorker<string[]> parser;
        private Dictionary<string,string>[] headersUrl;
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

        private void ParserOnNewData(object arg1, Dictionary<string,string> headersUrl)
        {
            this.headersUrl[pageValue] = headersUrl;
            pageValue++;


        }
        private void ParserOnComplited(object obj)
        {
            pageTextBlock.Text = "1";
            headersParserContentcontroll.Content = new PageHeadersControl(headersUrl[0]);
            pageValue = 1;
        }

        private void GoWorkParserBttClick(object sender, RoutedEventArgs e)
        {
            isActiveHeadersSearch = false;

            if (startPoint.Value <= endPoint.Value)
                StartWorkerParser();
            else
                MessageBox.Show("начальная страница должна быть меньше или равна конечной");
        }
        private void StartWorkerParser()
        {
            pageValue = 0;

            headersUrl = new Dictionary<string,string>[endPoint.Value];

            parser.ParserSettings = new ParserSettings(startPoint.Value, endPoint.Value);
            parser.Start();
        }

        private void NextPage(object sender, RoutedEventArgs e)
        {
            if (pageValue < headersUrl.Length && !isActiveHeadersSearch)
                SetNextPage();
        }

        private void SetNextPage()
        {
            pageValue++;
            headersParserContentcontroll.Content = new PageHeadersControl(headersUrl[pageValue - 1]);
            pageTextBlock.Text = $"{Convert.ToInt32(pageTextBlock.Text) + 1}";
        }

        private void PreviousPage(object sender, RoutedEventArgs e)
        {
            if (pageValue > 1 && !isActiveHeadersSearch)
                SetPreviousPage();
        }

        private void SetPreviousPage()
        {
            pageValue--;
            headersParserContentcontroll.Content = new PageHeadersControl(headersUrl[pageValue - 1]);
            pageTextBlock.Text = $"{Convert.ToInt32(pageTextBlock.Text) - 1}";
        }

        private void SearchHeaders(object sender, RoutedEventArgs e)
        {
            isActiveHeadersSearch = true;

            headersParserContentcontroll.Content = new PageHeadersControl(GetFoundHeaders());
        }

        private Dictionary<string,string> GetFoundHeaders()
        {
            Dictionary<string,string> searchHeaders = new Dictionary<string, string>();

            foreach (var pageHeaders in headersUrl)
            {
                foreach (var header in pageHeaders)
                {
                    if (IsCheckHeaders(header.Key))
                        searchHeaders.Add(header.Key,header.Value);
                }
            }

            return searchHeaders;
        }

        private bool IsCheckHeaders(string header)
        {
            char[] symbolSeprator = { ' ', ',', ';', ':', '!', '?', '.', '/', '"', '@', '№', '$', '%', '&', '(', ')', '<', '>' };
            string[] words = header.Split(symbolSeprator);

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == searchHeadersTextBox.Text)
                    return true;
            }

            return false;
        }

        private void ResetSearch(object sender, RoutedEventArgs e)
        {
            isActiveHeadersSearch = false;
            pageTextBlock.Text = "1";
            headersParserContentcontroll.Content = new PageHeadersControl(headersUrl[0]);
            pageValue = 1;
        }
    }
}
