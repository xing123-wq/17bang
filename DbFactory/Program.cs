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
            database.Delete();
            database.Create();
            new RegisterFactory().Create();
        }
    }
}
