using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;

namespace WPFDemo
{
    public class SingleApplicationBase : WindowsFormsApplicationBase
    {
        public SingleApplicationBase()
        {
            this.IsSingleInstance = true;//允许设置为单实例模式
        }

        private App wpfApp;//创建WPF的Application类


        //重载OnStartup方法。当应用程序启动时，创建WPF应用程序。
        protected override bool OnStartup(StartupEventArgs eventArgs)
        {
            //base.OnStartup(eventArgs);
            //wpfApp = new App();
            //wpfApp.Run();
            return false;
        }


        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            base.OnStartupNextInstance(eventArgs);
            if (eventArgs.CommandLine.Count > 0)
            {
                wpfApp.ShowWindowText(eventArgs.CommandLine[0]);
            }
        }

    }
}
