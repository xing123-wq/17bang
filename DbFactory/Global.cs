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
        internal static SQLContext context = new SQLContext();
        public static DateTime Time { get => DateTime.Now; }
    }
}
