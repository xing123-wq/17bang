using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queqry
{
    public static class OnComment
    {
        public static IList<Comment> Belong(
      this IList<Comment> source, Article article)
        {
            return source.Where(m => m.Article == article).ToList();
        }
    }
}
