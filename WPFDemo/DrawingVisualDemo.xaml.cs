using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// DrawingVisualDemo.xaml 的交互逻辑
    /// </summary>
    public partial class DrawingVisualDemo : Window
    {
        public DrawingVisualDemo()
        {
            InitializeComponent();

            MyVisualHot visualHost = new MyVisualHot();
            MyCanvas.Children.Add(visualHost);
        }


    }

    //创建一个派生自FrameworkElment的Visual宿主
    public class MyVisualHot : FrameworkElement
    {
        //创建子元素的集合私有变量
        private List<Visual> visuals = new List<Visual>();
        public MyVisualHot()
        {
            visuals.Add(CreateDrawingVisualRectangle());
            visuals.Add(CreateDrawingVisualText());
            visuals.Add(CreateDrawingVisualEllipses());
            this.MouseLeftButtonUp += new MouseButtonEventHandler(OnMouseLeftButtonDown);
        }

        public void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Point pt = e.GetPosition((UIElement)sender);//获取当前鼠标位置
            VisualTreeHelper.HitTest(this, null, new HitTestResultCallback(myCallback), new PointHitTestParameters(pt));
        }

        public HitTestResultBehavior myCallback(HitTestResult result)
        {
            if (result.VisualHit.GetType() == typeof(DrawingVisual))
            {
                if (((DrawingVisual)result.VisualHit).Opacity == 1.0)
                {
                    ((DrawingVisual)result.VisualHit).Opacity = 0.4;
                }
                else
                {
                    ((DrawingVisual)result.VisualHit).Opacity = 1;
                }
            }
            return HitTestResultBehavior.Stop;
        }

        //创建一个包含矩形的DrawingVisual
        private DrawingVisual CreateDrawingVisualRectangle()
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            //获取DrawingContext以便于创建一个绘图上下文
            DrawingContext drawingContext = drawingVisual.RenderOpen();
            Rect rect = new Rect(new Point(160, 100), new Size(320, 80));
            //绘制一个矩形

            drawingContext.DrawRectangle(Brushes.LightBlue, (Pen)null, rect);
            drawingContext.Close();
            return drawingVisual;
        }

        private DrawingVisual CreateDrawingVisualText()
        {
            //创建DrawingVisual实例
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();
            //在DrawingContext上下文中绘制格式化文本字符串
            drawingContext.DrawText(
                new FormattedText("单击",
                CultureInfo.GetCultureInfo("zh-cn"),
                FlowDirection.LeftToRight,
                new Typeface("Verdana"),
                36, Brushes.Black),
                new Point(200, 116));

            drawingContext.Close();
            //关闭DrawingContext以保存DrawingVisual的变更
            return drawingVisual;
        }
        //创建一个包含矩形的DrawingVisual
        private DrawingVisual CreateDrawingVisualEllipses()
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();
            //绘制矩形
            drawingContext.DrawEllipse(Brushes.Maroon, null, new Point(430, 136), 20, 20);
            drawingContext.Close();
            return drawingVisual;
        }

        //重载VisualChildrenCount()方法，返回当前DrawingVisual数量
        protected override int VisualChildrenCount { get { return visuals.Count; } }
        //提供所需的GetVisualChild（）重载方法
        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= visuals.Count)
            {
                throw new ArgumentException();
            }
            return visuals[index];
        }
    }
}
