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

namespace WPFDemo
{
    /// <summary>
    /// ExpanderDemo.xaml 的交互逻辑
    /// </summary>
    public partial class ExpanderDemo : Window
    {
        public ExpanderDemo()
        {
            InitializeComponent();
        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            txtText.Text = string.Empty;
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                txtText.Text += i + "\r\n";
            }
        }
    }
}
