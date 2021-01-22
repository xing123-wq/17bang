using System.Collections.Generic;
using System.Linq;
using BLL;

namespace Queqry
{
    public static class OnCategroy
    {
        public static IList<Category> ChildrenOf(
            this IList<Category> source, Category parent)
        {
            return source.Where(p => p.Parent == parent).ToList();
        }

        public static IList<Category> OwnedBy(
            this IList<Category> source, Users owner)
        {
            return source.Where(p => p.Author == owner).ToList();
        }
    }
}
