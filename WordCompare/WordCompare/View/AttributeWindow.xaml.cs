using Aspose.Words.Properties;
using Aspose.Words;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using WordCompare.Controller;
using System.Runtime.Remoting.Metadata;
using HandyControl.Controls;
using Window = System.Windows.Window;

namespace WordCompare.View
{
    /// <summary>
    /// AttributeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AttributeWindow : Window
    {

        public AttributeWindow()
        {
            InitializeComponent();
            this.DataContext=ViewModelController.attributeWindowVM;
        }
        /// <summary>
        /// 禁止修改窗口大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState != WindowState.Normal)
            {
                WindowState = WindowState.Normal;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            ViewModelController.attributeWindowVM.LoadAttribute();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModelController.attributeWindowVM.SaveAttribute())
            {
                Growl.Success("保存成功！");
            }
        }
    }

}
