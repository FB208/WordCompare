using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using WordCompare.Controller;
using WordCompare.Service;
using Window = System.Windows.Window;

namespace WordCompare.View
{
    /// <summary>
    /// IntersectWindow.xaml 的交互逻辑
    /// </summary>
    public partial class IntersectWindow : Window
    {
        public IntersectWindow()
        {
            InitializeComponent();
            this.DataContext = ViewModelController.intersectWindowVM;
            //lb_data.ItemsSource=ViewModelController.intersectWindowVM.ResultDict;
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            KeyValuePair<String, List<int>> kvp = (KeyValuePair<String, List<int>>)button.DataContext;

            Clipboard.SetText(kvp.Key);
            Growl.SuccessGlobal($"复制成功：{kvp.Key}");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //ViewModelController.intersectWindowVM.LoadContent();
            //Thread.Sleep(2000);
            //sp_Loading.Visibility = Visibility.Collapsed;
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            
        }

        private  void LoadContent() {
            ViewModelController.intersectWindowVM.LoadContent();
            Thread.Sleep(300);
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
            {
                lb_data.ItemsSource = ViewModelController.intersectWindowVM.ResultDict;
                sp_Loading.Visibility = Visibility.Collapsed;
            }));
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            Thread thread = new Thread(LoadContent);
            thread.Start();
           
        }

        private void Ignore_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            KeyValuePair<String, List<int>> kvp = (KeyValuePair<String, List<int>>)button.DataContext;

            IgnoreService.Add(kvp.Key);
            ViewModelController.intersectWindowVM.ResultDict.Remove(kvp);
        }
    }
}
