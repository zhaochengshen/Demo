using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SingleInstanceWithCommunication
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow win = new SingleInstanceWithCommunication.MainWindow();
            this.MainWindow = win;
            win.Show();
        }

        [STAThread]

        public static void Main(string[] args)
        {
            SingleApplicationBase sab = new SingleApplicationBase();
            sab.Run(args);

        }
    }


}
