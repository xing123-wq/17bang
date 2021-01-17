using System.Collections.Generic;
using System.Linq;
using BLL;

namespace Queqry
{
    public static class OnAdInWidget
    {
        public static IList<AdInWidget> Belong(this IList<AdInWidget> soure, Users user)
        {
            return soure.Where(a => a.Author == user).ToList();
        }

        public static IList<AdInWidget> NotDelete(this IList<AdInWidget> soure)
        {
            return soure.Where(a => !a.FlagDelete).ToList();
        }
    }
}
