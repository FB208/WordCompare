using Aspose.Words;
using Aspose.Words.Properties;
using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WordCompare.Common;
using WordCompare.Controller;
using WordCompare.Service;
using WordCompare.View;
using WordCompare.ViewModel;
using static System.Net.Mime.MediaTypeNames;
using Window = System.Windows.Window;

namespace WordCompare
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = ViewModelController.mainWindowVM;
        }

        private void btn_Intersect_Click(object sender, RoutedEventArgs e)
        {

            FileService fileService = new FileService();
            Dictionary<string, string> files = fileService.LoadFiles(ViewModelController.mainWindowVM.BaseFolderPath);
            lb_files.ItemsSource = files;

            IntersectWindow intersectWindow = new IntersectWindow();
            intersectWindow.Show();

            //List<string> txtList = service.load();
            //tb_Result.Clear();
            //foreach (var txt in txtList)
            //{
            //    tb_Result.AppendText($"{txt}\r\n");
            //    //tb_Result.Text += + "\r\n";

            //}
        }

        private void btn_SetPath_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog openFileDialog = new System.Windows.Forms.FolderBrowserDialog();  //选择文件夹

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)//注意，此处一定要手动引入System.Window.Forms空间，否则你如果使用默认的DialogResult会发现没有OK属性
            {

                ViewModelController.mainWindowVM.BaseFolderPath = openFileDialog.SelectedPath;
            }
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

        /// <summary>
        /// 打开使用说明
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Explain_Click(object sender, RoutedEventArgs e)
        {
            ExplainWindow explain = new ExplainWindow();
            explain.Show();
        }

        private void btn_Help4SplitSpace_Click(object sender, RoutedEventArgs e)
        {
            Growl.Info("当文档中有大量英文内容时，请关闭此选项，否则英文句子会被拆成单词，影响比对结果");
        }

        private void btn_SetAttribute_Click(object sender, RoutedEventArgs e)
        {
            string filePath = ((KeyValuePair<string, string>)lb_files.SelectedItem).Value;
            ViewModelController.attributeWindowVM.FilePath = filePath;
            AttributeWindow window = new AttributeWindow();
            window.ShowDialog();



        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //创建配置文件
            ViewModelController.ignoreFilePath= Directory.GetCurrentDirectory() + "\\ignore";
            FileService fileService = new FileService();
            fileService.CreateFileInThisPath("ignore");
            //读取配置文件
            new Thread(IgnoreService.Init).Start();
        }
    }
}
