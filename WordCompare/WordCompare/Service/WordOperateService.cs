//using Aspose.Cells;
using Aspose.Words;
using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using WordCompare.Common;
using WordCompare.Controller;

namespace WordCompare.Service
{
    public class WordOperateService
    {
        public List<string> load(string filePath)
        {
            // Load Word document
            
            string docTxt = "";

            try
            {
                //加载word，但是版本太新 aspose.word不能处理
                Document doc = new Document(filePath);
                docTxt = doc.Range.Text;//.Substring(80, doc.Range.Text.Length - 330);
            }
            catch
            {
                try
                {
                    //通过open xml sdk来加载word，但加载旧版doc则不行
                    using (WordprocessingDocument doc = WordprocessingDocument.Open(filePath, false))
                    {
                        docTxt = doc.MainDocumentPart.Document.Body.InnerText;
                    }
                }
                catch {
                    //尝试用txt来加载
                    var extension = Regex.Match(filePath, @"\\.([^.]+)$").Groups[1].Value;
                    if (extension.ToLower().Equals("txt"))
                    {
                        docTxt = File.ReadAllText(filePath);
                    }
                    else { MessageBox.Show($"未能成功加载文件【{filePath}】文件格式不标准，盲猜WPS的锅，可以把内容复制到记事本中重试，不影响比对结果。"); }
                }
                

            }


            char[] splitChars = new char[] {'！','!', '-', '—', '-', '_', '|',';','；','\'', '"', '‘', '’', '“', '”', '？', '?', '.', '。', '》', ',', '，' , '<', '《', '、', ':', '：','（', '）', '(', ')', '[', ']', '{', '}', '\r','\n','\f','\t' };
            #region 配置项
            if (ViewModelController.mainWindowVM.IsSplitSpace)
            {
                splitChars=splitChars.Append(' ').ToArray();
            }
            
            #endregion

            List<string> txtList = docTxt.Split(splitChars).Where(m=>
            {
                if (String.IsNullOrWhiteSpace(m))
                {
                    return false;
                }
                if (System.Text.Encoding.Default.GetBytes(m).Length > 10)
                {
                    return true;
                }
                return false;
            }
            ).ToList();
            return txtList;
            
            //// Save document in HTML format
            //doc.Save("html_output.html", Aspose.Words.SaveFormat.Html);

            //// Load the HTML file in an instance of Aspose.Cells.Workbook class
            //Workbook book = new Workbook("html_output.html");

            //// Save as JSON
            //book.Save("word-to-json.json", Aspose.Cells.SaveFormat.Json);
        }
    }
}
