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
using System.Windows.Shapes;

namespace WPFDemo
{
    /// <summary>
    /// BindSourceDemo.xaml 的交互逻辑
    /// </summary>
    public partial class BindSourceDemo : Window
    {
        public BindSourceDemo()
        {
            InitializeComponent();
        }
    }

    public class Person : INotifyPropertyChanged
    {
        private string name;
        //当属性变更时触发PropertyChanged事件通知更改
        public event PropertyChangedEventHandler PropertyChanged;
        public Person() { }
        public Person(string value)
        {
            this.name = value;
        }
        public string PersonName
        {
            get { return name; }
            set
            {
                name = value;
                if (PropertyChanged != null) {
                    PropertyChanged(this, new PropertyChangedEventArgs(PersonName));
                }
            }
        } 
    }
}
