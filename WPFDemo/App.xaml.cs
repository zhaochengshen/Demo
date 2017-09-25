using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Collections;
using System.Threading;

namespace WPFDemo
{


    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        Mutex mutex;

        protected override void OnStartup(StartupEventArgs e)
        {

            //base.OnStartup(e);
            //MainWindow win = new MainWindow();
            //this.MainWindow = win;
            //win.Show();
            //if (e.Args.Length > 0)
            //{
            //    ShowWindowText(e.Args[0]);
            //}


            //base.OnStartup(e);
            //string mutexName = "WPFDemo";
            //bool CreatedNew;
            //mutex = new Mutex(true, mutexName, out CreatedNew);

            //if (!CreatedNew)//如果有存在的实例，则关闭当前实例

            //{
            //    MessageBox.Show("已存在一个应用程序实例");
            //    Shutdown();

            //}
        }

        public void ShowWindowText(string fileName)
        {
            Window2 win = new Window2();
            win.Title = fileName;
            ((MainWindow)this.MainWindow).ListBox.Items.Add(fileName);
            win.LoadFile(fileName);
            win.Show();
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //该bool值将从命令行参数中获取。如果制定了特定的命令行参数，则将该bool值设置为true；
            bool startMinimized = false;

            ///使用Environment的GetCommandLineArgs方法获取命令行参数
            string[] args = Environment.GetCommandLineArgs();

            //命令行参数是一个字符串数组类型，遍历参数数组，寻找特定的命令行参数。
            foreach (string arge in args)
            {
                if (arge == "/StartMinimized")
                {
                    startMinimized = true;
                }
            }

            //创建应用程序主窗口，如果指定了命令行参数，则最小化运行应用程序。并在窗口显示第一个命令行参数。
            Window2 win = new Window2();
            if (startMinimized)
            {
                win.WindowState = WindowState.Minimized;
                win.Content = "当前命令行参数" + e.Args[0];
            }
            win.Show();
        }

        //重载OnActivated事件，在窗体被激活时触发。
        protected override void OnActivated(EventArgs e)
        {
            System.Diagnostics.Debug.Write("当前应用程序被激活");
            foreach (Window win in Windows)
            {
                if (win.IsActive)
                {
                    System.Diagnostics.Debug.WriteLine("当前的活动窗口是：" + win.Title);
                } 
            }
            base.OnActivated(e);
        }

        //重载OnDeactivated事件，在窗体被取消激活时触发。
        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
            System.Diagnostics.Debug.WriteLine("当前应用程序停止激活");
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            string err = "异常信息:" + e.Exception.Message.ToString();
            MessageBox.Show(err);
            e.Handled = true;
        }

        private void Application_SessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
            //询问用户是否允许终止会话
            string msg = string.Format("{0} 是否要终止Windows会话？", e.ReasonSessionEnding);
            MessageBoxResult result = MessageBox.Show(msg, "Session Ending", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {//如果点击yes，允许终止，否则禁止终止会话
                e.Cancel = true;
            }

        }
        /// <summary>
        /// 应用程序退出标志
        /// </summary>
        public enum ApplicationExitCode
        {
            Success = 0,
            Failure = 1,
            CantWriteToApplicationLog = 2,
            CantPersistApplicationState = 3
        }

        /// <summary>
        /// 应用程序退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            try
            {
                if (e.ApplicationExitCode == (int)ApplicationExitCode.Success)
                {
                    WriteApplicationLogEntry("Failure", e.ApplicationExitCode);
                }
                else
                {
                    WriteApplicationLogEntry("Success", e.ApplicationExitCode);
                }
            }
            catch
            {
                //写入应用程序失败时，更新退出代码已反映出写入失败
                e.ApplicationExitCode = (int)ApplicationExitCode.CantWriteToApplicationLog;

            }

            //保存应用程序状态
            try
            {
                PersistApplicationState();
            }
            catch
            {
                //写入应用程序失败时，更新退出代码已反映出写入失败
                e.ApplicationExitCode = (int)ApplicationExitCode.CantPersistApplicationState;
            }
        }
        /// <summary>
        /// 记录应用程序日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exitCode"></param>
        private void WriteApplicationLogEntry(string message, int exitCode)
        {
            //写入日志项到用户隔离存储区
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForAssembly();
            using (Stream stream = new IsolatedStorageFileStream("log.txt", FileMode.Append, FileAccess.Write, store))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    string entry = string.Format("{0}:{1} - {2}", message, exitCode, DateTime.Now);
                    writer.WriteLine(entry);
                }
            }
        }
        /// <summary>
        /// 记录应用程序状态日志
        /// </summary>
        private void PersistApplicationState()
        {
            //保存应用程序状态到用户隔离存储区
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForAssembly();
            using (Stream stream = new IsolatedStorageFileStream("state.txt", FileMode.Create, store))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                //可以在这里更改为自定义的保存应用程序状态的程序代码
                foreach (DictionaryEntry entry in this.Properties)
                {
                    writer.WriteLine(entry.Value);
                }
            }
        }
    }
}
