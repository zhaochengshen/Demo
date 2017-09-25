using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

//添加命名空间
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;

namespace SingleInstanceWithCommunication
{
    public class SingleApplicationBase : WindowsFormsApplicationBase
    {
        public SingleApplicationBase()
        {
            this.IsSingleInstance = true;   //设置为允许单例模式
        }

        private App wpfApp;

        protected override bool OnStartup(StartupEventArgs eventArgs)
        {
            wpfApp = new App();
            wpfApp.Run();
            return false;
        }
        //当有其他应用程序实例化时，则出发此事件，将WPF应用程序中显示一个新的窗口
        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            base.OnStartupNextInstance(eventArgs);
            Console.WriteLine("启动实例");
        }

    }
}