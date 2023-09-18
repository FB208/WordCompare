using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCompare.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCompare.Common.Tests
{
    [TestClass()]
    public class UnicodeHelperTests
    {
        [TestMethod()]
        public void DecodeTest()
        {
            string str = "张三李四，王五赵六";
            //UnicodeHelper helper = new UnicodeHelper();
            string encode = UnicodeHelper.Encode(str);
            Console.WriteLine(encode);
            string decode = UnicodeHelper.Decode(encode);
            Console.WriteLine(decode);
            Assert.Fail();
        }
    }
}