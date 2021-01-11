using Global;
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
        public static IList<TRoot> Paged<TRoot>(this IList<TRoot> query, Pager pager)
        {
            return query.Skip((pager.Index - 1) * pager.Size).Take(pager.Size).ToList();
        }
    }
}
