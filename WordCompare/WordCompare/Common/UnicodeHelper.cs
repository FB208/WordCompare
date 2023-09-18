using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCompare.Common
{
    public static class UnicodeHelper
    {
        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public static string Decode(string codes)
        {
            return (System.Text.RegularExpressions.Regex.Unescape(codes));
        }

        public static string Encode(string codes)
        {
            StringBuilder tmp = new StringBuilder();
            foreach (var t in codes)
            {
                ushort uxc = (ushort)t;
                tmp.Append(@"\u" + uxc.ToString("x4"));
            }
            return (tmp.ToString());
        }
    }
}
