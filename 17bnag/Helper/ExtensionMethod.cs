using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bnag.Helper
{
    public static class ExtensionMethod
    {
        public static IEnumerable<T> Get<T>(this IEnumerable<T> soure, int pageindex, int pagesize)
        {
            return soure.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        public static int GetSum<T>(this IEnumerable<T> parameter)
        {
            return parameter.Count();
        }
    }
}
