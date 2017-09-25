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
    /// BurshDemo.xaml 的交互逻辑
    /// </summary>
    public partial class BurshDemo : Window
    {
        public BurshDemo()
        {
            InitializeComponent();
            CreateButton();

            btnOpacity.Background = new SolidColorBrush(Color.FromArgb(0, 100, 100, 100));
        }

        public void CreateButton()
        {
            Button btn = new Button();
            btn.Content = "使用后台代码创建Button，并设置背景色和前景色为渐变";
            btn.Margin = new Thickness(10);
            Grid.SetRow(btn, 2);
            grd.Children.Add(btn);

            //创建按钮前景渐变色
            LinearGradientBrush foreGroundColor = new LinearGradientBrush();
            foreGroundColor.StartPoint = new Point(0.5, 0.5);
            foreGroundColor.EndPoint = new Point(1, 1);
            foreGroundColor.GradientStops.Add(
                new GradientStop(Colors.Aqua, 0)
                );
            foreGroundColor.GradientStops.Add(
               new GradientStop(Colors.Aqua, 0.5)
               );
            foreGroundColor.GradientStops.Add(
               new GradientStop(Colors.Aqua, 0.75)
               );
            foreGroundColor.GradientStops.Add(
               new GradientStop(Colors.Aqua, 1)
               );
            btn.Foreground = foreGroundColor;


            //创建按钮背景渐变颜色
            LinearGradientBrush backGroundColor = new LinearGradientBrush();
            backGroundColor.StartPoint = new Point(0.5, 0.5);
            backGroundColor.EndPoint = new Point(1, 1);
            backGroundColor.GradientStops.Add(
                new GradientStop(Colors.AliceBlue, 0)
                );
            backGroundColor.GradientStops.Add(
                new GradientStop(Colors.Red, 0.4)
                );
            backGroundColor.GradientStops.Add(
                new GradientStop(Colors.Black, 0.75)
                );
            backGroundColor.GradientStops.Add(
                new GradientStop(Colors.Blue, 1)
                );
            btn.Background = backGroundColor;
        }
    }
}
