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
    /// ListBoxDemo.xaml 的交互逻辑
    /// </summary>
    public partial class ListBoxDemo : Window
    {
        public ListBoxDemo()
        {
            InitializeComponent();
        }
        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem item = (sender as ListBox).SelectedItem as ListBoxItem;
            listBox1.Items.Remove(item);
            listBox1_Selected.Items.Add(item);

        }
        private void listBox1_Selected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem item = (sender as ListBox).SelectedItem as ListBoxItem;
            listBox1_Selected.Items.Remove(item);
            listBox1.Items.Add(item);
        }
        private void btnList2Ok_Click(object sender, RoutedEventArgs e)
        {
            foreach (ListBoxItem item in listbox2.Items)
            {
                if ((item.Content as CheckBox).IsChecked == true)
                {
                    listbox2_Selected.Items.Add((item.Content as CheckBox).Content);
                }

            }
        }
        private void btnList2Cancel_Click(object sender, RoutedEventArgs e)
        {
            listbox2_Selected.Items.Clear();
        }
    }
}
