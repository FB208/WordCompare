//using Aspose.Cells;
using Aspose.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCompare.Common;
using WordCompare.Controller;

namespace WordCompare.Service
{
    public class WordOperateService
    {
        public List<string> load(string filePath)
        {
            // Load Word document
            Document doc = new Document(filePath);
            string docTxt = doc.Range.Text;//.Substring(80, doc.Range.Text.Length - 330);
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
