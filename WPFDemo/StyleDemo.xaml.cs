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
    /// StyleDemo.xaml 的交互逻辑
    /// </summary>
    public partial class StyleDemo : Window
    {
        public StyleDemo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 定义当鼠标移动到按钮的事件
        /// </summary>
        public void ButtonMouseEnter(object sender, MouseEventArgs e)
        {
            ((Button)sender).Foreground = new SolidColorBrush(Colors.Blue);
        }

        /// <summary>
        /// 定义当鼠标移动出按钮的事件
        /// </summary>
        public void ButtonMouseLeave(object sender, MouseEventArgs e)
        {
            ((Button)sender).Foreground = new SolidColorBrush(Colors.Black);
        }

    }
}
