using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCompare.Controller;

namespace WordCompare.Service
{
    public class FileService
    {

        public Dictionary<string, string> LoadFiles(string dictionary)
        {
            string[] files = Directory.GetFiles(ViewModelController.mainWindowVM.BaseFolderPath);
            Dictionary<string, string> result = new Dictionary<string, string>();
            for (int i = 0; i < files.Length; i++)
            {
                string fileName = files[i].Split('\\').Last();
                //if (fileName.Length>20)
                //{
                //    fileName = fileName.Substring(0,20)+"...";
                //}
                result.Add(fileName, files[i]);
            }
            return result;
        }

        public void CreateFileInThisPath(string fileName)
        {
            string currentPath = Directory.GetCurrentDirectory();
            string ignorePath = $"{currentPath}\\{fileName}";
            if (!File.Exists(ignorePath))
            {
                File.Create(ignorePath);
            }
        }
    }
}
