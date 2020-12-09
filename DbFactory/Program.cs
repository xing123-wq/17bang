using Repositorys;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new SQLContext().Database;
            database.Log = Console.Write;
            database.Delete();
            database.Create();
            #region envision
            RegisterFactory.Create();
            ArticleFactory.Create();
            #endregion
            Global.context.SaveChanges();
        }
    }
}
