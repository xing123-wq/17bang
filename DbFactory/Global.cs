using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFactory
{
    static class Global
    {
        internal static SqlContext context = new SqlContext();
        public static DateTime Time { get => DateTime.Now; }
    }
}
