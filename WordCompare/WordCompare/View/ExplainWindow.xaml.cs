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

namespace WordCompare.View
{
    /// <summary>
    /// ExplainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ExplainWindow : Window
    {
        public ExplainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            WebBrowser webBrowser = new WebBrowser();
            webBrowser.Source = new Uri("http://qiniu.bigdudu.cn/比对软件使用说明.pdf");
            this.Content = webBrowser;
        }
    }
}
