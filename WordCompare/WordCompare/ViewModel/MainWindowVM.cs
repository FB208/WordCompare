using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCompare.Common;
using WordCompare.Controller;
using WordCompare.Service;

namespace WordCompare.ViewModel
{
    public class MainWindowVM : BaseVM
    {
        private bool isSplitSpace = true;
        /// <summary>
        /// 空格是否算分隔符
        /// </summary>
        public bool IsSplitSpace
        {
            get => isSplitSpace;
            set
            {
                isSplitSpace = value; 
                this.DoNotify();

            }
        }

        private string baseFolderPath;
        /// <summary>
        /// 对比文件所在文件夹路径
        /// </summary>
        public string BaseFolderPath
        {
            get => baseFolderPath;
            set
            {
                baseFolderPath = value;
                this.DoNotify();

            }
        }



        public void Intersect()
        {
            
        }
    }
}
