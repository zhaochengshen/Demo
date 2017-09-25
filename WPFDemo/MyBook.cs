using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFDemo
{
    public class MyBook : DependencyObject
    {

        public static readonly DependencyProperty BookNameProperty;
        static MyBook()
        {
            BookNameProperty = DependencyProperty.Register("BookName", typeof(string), typeof(MyBook),
                new PropertyMetadata("No Name",
                new PropertyChangedCallback(BookNameChangedCallback),
                new CoerceValueCallback(BookNameCoerceCallback)),
                new ValidateValueCallback(BookNameValidateCallback)
            );
        }

        private static void BookNameChangedCallback(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.OldValue + " " + e.NewValue);
        }

        private static object BookNameCoerceCallback(DependencyObject obj, object o)
        {
            string s = o as string;
            if (s.Length > 0)
            {
                s = s.Substring(0, 8);
            }
            return s;
        }
        private static bool BookNameValidateCallback(object value)
        {
            return value != null;
        }

        public string BookName
        {
            get { return (string)GetValue(BookNameProperty); }
            set { SetValue(BookNameProperty, value); }
        }



    }
}
