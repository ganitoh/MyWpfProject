using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MyWpfProject.View.MainView.ParserView.controls
{
    partial class PageHeadersControl : UserControl
    {
        Dictionary<string, string> headersUrl = new Dictionary<string, string>();
        public PageHeadersControl(Dictionary<string,string> headersUrl)
        {
            InitializeComponent();

            foreach (var header in headersUrl)
            {
                Button headerButton = new Button();
                headerButton.Content = header.Key;
                headerButton.Margin = new Thickness(5);
                headerButton.Click += (e,o) =>
                {
                    Process.Start($"{header.Value}");
                };

                headersPanel.Children.Add(headerButton);
            }
        }
    }
}
