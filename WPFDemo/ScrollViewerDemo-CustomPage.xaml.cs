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
    /// ScrollViewerDemo_CustomPage.xaml 的交互逻辑
    /// </summary>
    public partial class ScrollViewerDemo_CustomPage : Window
    {
        public ScrollViewerDemo_CustomPage()
        {
            InitializeComponent();
            BindText();
        }
        public void BindText()
        { 
            for (int i = 0; i < 1000; i++)
            {
                txtText.Text += i + "\r\n";
            }
        }

        private void btnLineUp_Click(object sender, RoutedEventArgs e)
        {
            SVText.LineUp();
        }
         
        private void btnLineDown_Click(object sender, RoutedEventArgs e)
        {
            SVText.LineDown();
        }

        private void btnLineLeft_Click(object sender, RoutedEventArgs e)
        {
            SVText.LineLeft();
        }

        private void btnLineRight_Click(object sender, RoutedEventArgs e)
        {
            SVText.LineRight();
        }
         
        private void btnPageUp_Click(object sender, RoutedEventArgs e)
        {
            SVText.PageUp();
        }

        private void btnPageDown_Click(object sender, RoutedEventArgs e)
        {
            SVText.PageDown();
        }

        private void btnPageLeft_Click(object sender, RoutedEventArgs e)
        {
            SVText.PageLeft();
        }

        private void btnPageRight_Click(object sender, RoutedEventArgs e)
        {
            SVText.PageRight();
        }

        private void btnLineHome_Click(object sender, RoutedEventArgs e)
        {
            SVText.ScrollToHome();
        }

        private void btnLineEnd_Click(object sender, RoutedEventArgs e)
        {
            SVText.ScrollToEnd();
        }

        private void btnColumnHome_Click(object sender, RoutedEventArgs e)
        {
            SVText.ScrollToLeftEnd();
        }

        private void btnColumnEnd_Click(object sender, RoutedEventArgs e)
        {
            SVText.ScrollToRightEnd();
        }

        private void btnLineOffsetUp_Click(object sender, RoutedEventArgs e)
        {
            SVText.ScrollToVerticalOffset(SVText.VerticalOffset + 3);
        }

        private void btnColumnOffsetRight_Click(object sender, RoutedEventArgs e)
        {
            SVText.ScrollToHorizontalOffset(SVText.HorizontalOffset + 3);
        }

        private void btnLineOffsetDown_Click(object sender, RoutedEventArgs e)
        {
            SVText.ScrollToVerticalOffset(SVText.VerticalOffset - 3);
        }

        private void btnColumnOffsetLeft_Click(object sender, RoutedEventArgs e)
        {
            SVText.ScrollToHorizontalOffset(SVText.HorizontalOffset - 3);
        }
    }
}
