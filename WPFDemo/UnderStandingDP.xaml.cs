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
    /// UnderStandingDP.xaml 的交互逻辑
    /// </summary>
    public partial class UnderStandingDP : Window
    {
        public UnderStandingDP()
        {
            InitializeComponent();
        }

        private void btnWindowSize_Click(object sender, RoutedEventArgs e)
        {
            this.FontSize = 30;
        }

        private void btnButtonSize_Click(object sender, RoutedEventArgs e)
        {
            this.FontSize = 5;
        }
    }
}
