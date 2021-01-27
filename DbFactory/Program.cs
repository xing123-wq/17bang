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
            Database database = new SqlContext().Database;
            database.Log = Console.Write;
            database.Delete();
            database.Create();
            #region envision  
            //有顺序，多对多关系的表，必须先创建两张表，中间表必须在两张表后面
            Funcsh(RegisterFactory.Create);
            Funcsh(CategoryFactory.Create);
            Funcsh(ArticleFactory.Create);
            Funcsh(KeywordFactory.Create);
            Funcsh(ArticleAndKeywordFactory.Create);
            Funcsh(AdInWidgetFactory.Create);
            Funcsh(CommentFactory.Create);
            #endregion
            Global.context.SaveChanges();
        }

        public static void Funcsh(Action action)
        {
            action();
        }
    }
}
