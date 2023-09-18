using Aspose.Words;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using WordCompare.Common;
using WordCompare.Controller;
using WordCompare.Service;

namespace WordCompare.ViewModel
{
    public class IntersectWindowVM : BaseVM
    {


        private ObservableCollection<KeyValuePair<string, List<int>>> resultDict=new ObservableCollection<KeyValuePair<string, List<int>>>();
        /// <summary>
        /// 结果集
        /// </summary>
        public ObservableCollection<KeyValuePair<string, List<int>>> ResultDict
        {
            get => resultDict;
            set
            {
                resultDict = value;
                this.DoNotify();

            }
        }

        private string consoleMessage;
        /// <summary>
        /// 控制台显示内容
        /// </summary>
        public string ConsoleMessage
        {
            get => consoleMessage;
            set { consoleMessage = value; this.DoNotify(); }
        }


        //private List<string> ignoreList;
        ///// <summary>
        ///// 控制台显示内容
        ///// </summary>
        //public List<string> IgnoreList
        //{
        //    get => ignoreList;
        //    set { ignoreList = value; this.DoNotify(); }
        //}

        /// <summary>
        /// 分析文档内容，在独立线程中完成
        /// </summary>
        public void LoadContent()
        {
            //等待加载完忽略文件
            while (IgnoreService.LockKey)
            {
                
            }
            //读取
            //ViewModelController.intersectWindowVM.IgnoreList =
            WordOperateService service = new WordOperateService();
            //文件夹内的几个文件路径
            string[] files = Directory.GetFiles(ViewModelController.mainWindowVM.BaseFolderPath);
            //几个文件读取出的句子，每个文件一组
            List<string>[] lineListGroup = new List<string>[files.Length];
            //所有文件中的句子集合
            List<string> allLineList = new List<string>();
            for (int i = 0; i < files.Length; i++)
            {
                lineListGroup[i] = service.load(files[i]);
                allLineList.AddRange(lineListGroup[i]);
            }

            allLineList = allLineList.Distinct().Except(IgnoreService.IgnoreList).ToList();


            //结果集合
            
            foreach (var line in allLineList)
            {
                List<int> indexs = new List<int>();
                for (int i = 0; i < lineListGroup.Length; i++)
                {
                    if (lineListGroup[i].Any(m => m.Equals(line)))
                    {
                        indexs.Add(i);
                    }
                }
                if (indexs.Count > 1)
                {
                    KeyValuePair<string, List<int>> resultDict = new KeyValuePair<string, List<int>>(line, indexs);
                    ViewModelController.intersectWindowVM.ResultDict.Add(resultDict); 
                }
            }

            // 指定文件路径和名称
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "重复句子.txt");

            // 将内容写入文件
            using (StreamWriter writer = new StreamWriter(filepath))
            {
                foreach (var item in ViewModelController.intersectWindowVM.ResultDict)
                {
                    writer.WriteLine(item.Key);
                }
            }

        }
        
    }
}
