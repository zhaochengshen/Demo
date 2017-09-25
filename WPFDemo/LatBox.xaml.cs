using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WPFDemo
{
    /// <summary>
    /// LatBox.xaml 的交互逻辑
    /// </summary>
    public partial class LatBox : UserControl
    {
        public LatBox()
        {
            InitializeComponent();
        }
        public static DependencyProperty ValueProperty = DependencyProperty.Register("Value",
          typeof(Coordinate), typeof(LatBox),
          new FrameworkPropertyMetadata(null,
              FrameworkPropertyMetadataOptions.AffectsMeasure |
              FrameworkPropertyMetadataOptions.AffectsRender |
              FrameworkPropertyMetadataOptions.BindsTwoWayByDefault |
              FrameworkPropertyMetadataOptions.Inherits,
              new PropertyChangedCallback(OnValueChanged),
              new CoerceValueCallback(CoerceValue)
              ));
        //定义强制值回调，限制输入的数据不可以小于0，大于90，小于-180，大于180
        static object CoerceValue(DependencyObject sender, object value)
        {
            Coordinate val = value as Coordinate;
            if (val != null)
            {
                if (val.Latitude < 0) { val.Latitude = 0; }
                else if (val.Latitude > 90) { val.Latitude = 90; }

                if (val.Longitude < -180) { val.Longitude = -180; }
                else if (val.Longitude > 180) { val.Longitude = 180; }
            }
            return val;

        }
        //属性值更改时，出发用户界面的更新，并更新用户界面
        static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            LatBox box = sender as LatBox;
            box.UpdateValue();
            RoutedPropertyChangedEventArgs<Coordinate> e = new RoutedPropertyChangedEventArgs<Coordinate>(
                (Coordinate)args.OldValue, (Coordinate)args.NewValue, ValueChangedEvent);
            box.OnValueChanged(e);
        }

        public void UpdateValue()
        {
            Lat.Text = Value.Latitude.ToString();
            Lon.Text = Value.Longitude.ToString();
        }

        //触发时间
        public void OnValueChanged(RoutedPropertyChangedEventArgs<Coordinate> e)
        {
            RaiseEvent(e);
        }

        public Coordinate Value
        {
            get { return (Coordinate)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent(
            "ValueChanged", RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<Coordinate>), typeof(LatBox));

        public event RoutedPropertyChangedEventHandler<Coordinate> ValueChanged
        {
            add { AddHandler(ValueChangedEvent, value); }
            remove { RemoveHandler(ValueChangedEvent, value); }
        }

        void onTextChanged(object sender, TextChangedEventArgs e)
        {
            double lat = 0;
            double lon = 0;
            if (double.TryParse(Lat.Text == string.Empty ? "0" : Lat.Text, out lat) &
                double.TryParse(Lon.Text == string.Empty ? "0" : Lon.Text, out lon))
            {
                Value = new Coordinate(lat, lon);
            }
            else
            {
                UpdateValue();
            }
        }

    }

    public class Coordinate : INotifyPropertyChanged
    {

        private double m_lat;
        public double Latitude
        {
            get { return m_lat; }
            set
            {
                m_lat = value;
                FirePropertyChanged("Latitude");
            }
        }

        private double m_long;
        public double Longitude
        {
            get { return m_long; }
            set
            {
                m_long = value;
                FirePropertyChanged("Longitude");
            }
        }

        public Coordinate(double lat, double lon)
        {
            this.Latitude = lat;
            this.Longitude = lon;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
