using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Common
{
    public static class StringExtension
    {
        #region 判断当前字符串是否为空
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        } 
        #endregion
    }
}
