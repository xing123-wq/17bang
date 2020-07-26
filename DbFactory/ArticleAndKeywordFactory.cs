using BLL;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFactory
{
    class ArticleAndKeywordFactory
    {
        public static IList<ArticleAndKeyword> sqls, javas, uis;
        public static ArticleAndKeyword sql, java, ui;
        static ArticleAndKeywordFactory()
        {
            sql = new ArticleAndKeyword
            {
                Article = ArticleFactory.SQL,
                Keyword = KeywordFactory.sql
            };
            java = new ArticleAndKeyword
            {
                Article = ArticleFactory.JAVA,
                Keyword = KeywordFactory.java
            };
            ui = new ArticleAndKeyword
            {
                Article = ArticleFactory.UI,
                Keyword = KeywordFactory.html
            };
            sqls = new List<ArticleAndKeyword> { sql };
            javas = new List<ArticleAndKeyword> { ui };
            uis = new List<ArticleAndKeyword> { java };
        }
        //public static void Create()
        //{
        //    new BaseRepository<ArticleAndKeyword>(Global.context).AddRange(sqls);
        //    new BaseRepository<ArticleAndKeyword>(Global.context).AddRange(javas);
        //    new BaseRepository<ArticleAndKeyword>(Global.context).AddRange(uis);
        //}
    }
}
