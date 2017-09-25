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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFDemo
{
    /// <summary>
    /// ProgressBarDemo.xaml 的交互逻辑
    /// </summary>
    public partial class ProgressBarDemo : Window
    {
        public ProgressBarDemo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Duration duration = new Duration(TimeSpan.FromMilliseconds(2000));
            DoubleAnimation doubleanimation = new DoubleAnimation(100.0, duration);
            prog1.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
        }
    }
}
