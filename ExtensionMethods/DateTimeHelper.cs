using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class DateTimeHelper
    {
        public static string ToChinese(this DateTime source)
        {
            return string.Format("{0:F}", source);
        }
    }
}
