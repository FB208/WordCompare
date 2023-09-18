using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace WordCompare
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.Startup += new StartupEventHandler(App_Startup); // 注册开始事件

            this.Exit += new ExitEventHandler(App_Exit);          // 注册退出事件
        }
        // 进程启动
        private void App_Startup(object sender, StartupEventArgs e)
        {
            // UI线程未捕获异常处理事件
            DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(Startup_DispatcherUnhandledException);

            //Task线程内未捕获异常处理事件
            TaskScheduler.UnobservedTaskException += Startup_UnobservedTaskException;

            //非UI线程未捕获异常处理事件
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Startup_UnhandledException);
        }

        private void Startup_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                //把 Handled 属性设为true，表示此异常已处理，程序可以继续运行，不会强制退出
                e.Handled = true;
                MessageBox.Show(e.Exception.Message);
                // 这里可以写一下错误日志
            }
            catch (Exception ex)
            {
                //此时程序出现严重异常，将强制结束退出

                // 这里可以写一下错误日志

                MessageBox.Show("程序发生致命错误，将终止！", "BUG");
            }
        }

        private void Startup_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {

        }

        private void Startup_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            StringBuilder sbEx = new StringBuilder();

            if (e.IsTerminating)
            {
                sbEx.Append("程序发生致命错误，将终止！\n");
            }

            sbEx.Append("捕获未处理异常：");

            if (e.ExceptionObject is Exception)
            {
                sbEx.Append(((Exception)e.ExceptionObject).Message);
            }
            else
            {
                sbEx.Append(e.ExceptionObject);
            }

            MessageBox.Show(sbEx.ToString());
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            //程序退出时需要处理的业务
        }
    }
}
