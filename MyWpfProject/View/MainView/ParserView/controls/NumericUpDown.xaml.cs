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
    partial class NumericUpDown : UserControl
    {
        private int _value;
        public event Action <string> Handler;

        public int Value { get => _value; }

        public NumericUpDown()
        {
            InitializeComponent();

            _value = 0;
            valueTextBox.Text = _value.ToString();
        }

        
        private void UpValue(object sender, RoutedEventArgs e)
        {
            _value++;
            valueTextBox.Text = _value.ToString();
        }

        private void DownValue(object sender, RoutedEventArgs e)
        {

            if (_value > 0)
            {
                _value--;
                valueTextBox.Text = _value.ToString();
            }
            
        }

        private void SetValueText(object sender, TextChangedEventArgs e)
        {
            try
            {
                _value = Convert.ToInt32(valueTextBox.Text);
            }
            catch (Exception )
            {
                string exceptionMessage = "некоректные символы";
                Handler?.Invoke(exceptionMessage);
                _value = 0;
                valueTextBox.Text = _value.ToString();
            }
        }
    }
}
