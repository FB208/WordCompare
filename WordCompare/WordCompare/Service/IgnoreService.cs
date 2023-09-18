using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Shapes;
using WordCompare.Common;
using WordCompare.Controller;

namespace WordCompare.Service
{
    public static class IgnoreService
    {
        public static List<string> IgnoreList = new List<string>();
        public static bool LockKey = false;
        public static void Init()
        {
            LockKey = true;
            string ignoreString = File.ReadAllText(ViewModelController.ignoreFilePath);
            string ignoreStringDecode = UnicodeHelper.Decode(ignoreString);
            IgnoreList = ignoreStringDecode.Split(',').ToList();
            //Thread.Sleep(20000);
            LockKey=false;
        }
        public static void Add(string word)
        {
            IgnoreList.Add(word);
            using (FileStream fs = new FileStream(ViewModelController.ignoreFilePath, FileMode.OpenOrCreate,
                       FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.BaseStream.Seek(0, SeekOrigin.End);
                    sw.Write(UnicodeHelper.Encode($"{word},"));
                    sw.Flush();
                }
            }
        }
    }
}
