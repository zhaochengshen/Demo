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
    /// PolyLineDemo.xaml 的交互逻辑
    /// </summary>
    public partial class PolyLineDemo : Window
    {
        public PolyLineDemo()
        {
            InitializeComponent();
            CreateTian();
        }

        public void CreateTian()
        {
            Polyline myPolyline = new Polyline();
            myPolyline.Stroke = Brushes.Black;
            myPolyline.StrokeThickness = 2;
            //指定坐标  
            PointCollection ps = new PointCollection();
            ps.Add(new Point(120, 10));
            ps.Add(new Point(220, 10));
            ps.Add(new Point(220, 110));
            ps.Add(new Point(120, 110));
            ps.Add(new Point(120, 10));
            ps.Add(new Point(170, 10));
            ps.Add(new Point(170, 110));
            ps.Add(new Point(120, 110));
            ps.Add(new Point(120, 60));
            ps.Add(new Point(220, 60));

            myPolyline.Points = ps;
            canvas1.Children.Add(myPolyline);
        }
    }
}
