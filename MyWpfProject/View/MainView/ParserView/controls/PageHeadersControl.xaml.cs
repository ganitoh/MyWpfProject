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
        List<string> headers = new List<string>();
        public PageHeadersControl(List<string> headers)
        {
            this.headers = headers.ToList<String>();
            InitializeComponent();

            foreach (string header in this.headers)
            {
                Button headerButton = new Button();
                headerButton.Content = header;
                headerButton.Margin = new Thickness(5);

                headersPanel.Children.Add(headerButton);
            }
        }
    }
}
