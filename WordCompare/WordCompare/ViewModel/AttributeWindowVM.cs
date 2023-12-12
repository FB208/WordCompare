using Aspose.Words.Properties;
using Aspose.Words;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCompare.Common;
using WordCompare.Controller;
using HandyControl.Tools.Extension;
using Aspose.Words.Saving;
using System.Windows;

namespace WordCompare.ViewModel
{
    public class AttributeWindowVM : BaseVM
    {
        private string filePath;
        /// <summary>
        /// 要读取的文件路径
        /// </summary>
        public string FilePath
        {
            get => filePath;
            set
            {
                filePath = value;
                this.DoNotify();

            }
        }

        private string author;
        /// <summary>
        /// 作者
        /// </summary>
        public string Author
        {
            get => author;
            set
            {
                author = value;
                this.DoNotify();
            }
        }

        private DateTime createTime;
        /// <summary>
        /// 创建内容时间
        /// </summary>
        public DateTime CreateTime
        {
            get => createTime;
            set
            {
                createTime = value;
                this.DoNotify();
            }
        }

        private string lastSavedBy;
        /// <summary>
        /// 最后一次保存者
        /// </summary>
        public string LastSavedBy
        {
            get => lastSavedBy;
            set
            {
                lastSavedBy = value;
                this.DoNotify();
            }
        }

        private DateTime lastSavedTime;
        /// <summary>
        /// 最后一次保存的日期
        /// </summary>
        public DateTime LastSavedTime
        {
            get => lastSavedTime;
            set
            {
                lastSavedTime = value;
                this.DoNotify();
            }
        }

        private DateTime lastPrinted;
        /// <summary>
        /// 最后一次打印的时间
        /// </summary>
        public DateTime LastPrinted
        {
            get => lastPrinted;
            set
            {
                lastPrinted = value;
                this.DoNotify();
            }
        }

        public void LoadAttribute()
        {
            try
            {
                Document doc = new Document(FilePath);

                var properties = doc.BuiltInDocumentProperties;
                Author = properties.Author;
                LastSavedBy = properties.LastSavedBy;
                LastPrinted = properties.LastPrinted.AddHours(8);
                LastSavedTime = properties.LastSavedTime.AddHours(8);
                CreateTime = properties.CreatedTime.AddHours(8);
            }
            catch
            {
                MessageBox.Show("Word版本太新了，当前程序无法解析");
                
            }
            


            //foreach (DocumentProperty item in doc.BuiltInDocumentProperties)
            //{
            //    //Trace.WriteLine(item.Name + ":" + item.Value);
            //    if (item.Name.Equals("LastSavedTime"))
            //    {
            //        item.Value = DateTime.Parse("2024-3-8 12:12:12").AddHours(-8);
            //    }
            //}
            //doc.Save(FilePath);
        }

        public bool SaveAttribute()
        {
            Document doc = new Document(FilePath);

            var properties = doc.BuiltInDocumentProperties;

            properties.Author = Author;
            properties.LastSavedBy = LastSavedBy;
            properties.LastPrinted = LastPrinted.AddHours(-8);
            properties.LastSavedTime = LastSavedTime.AddHours(-8);
            properties.CreatedTime = CreateTime.AddHours(-8);
            SaveOutputParameters aa =doc.Save(FilePath);
            return true;
        }
    }
}
