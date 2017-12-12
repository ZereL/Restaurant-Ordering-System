using Microsoft.International.Converters.PinYinConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterCommon
{
    public partial class PinyinHelper
    {
        public static string GetPinyin(string s1)
        {
            string s2 = "";
            foreach (var c in s1)
            {
                ChineseChar cc = new ChineseChar(c);
                s2 += cc.Pinyins[0][0];
            }
            return s2;
        }

    }
}
