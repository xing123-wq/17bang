using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ExtensionMethods
{
    public static class Select
    {
        public static int GetSum<T>(this IEnumerable<T> parameter)
        {
            return parameter.Count();
        }
        public static IEnumerable<T> Get<T>(this IEnumerable<T> soure, int pageindex, int pagesize)
        {
            return soure.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
    }
}
