using BLL;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFactory
{
    class KeywordFactory
    {
        public static Keyword sql, java, html;
        public static void Create()
        {
            sql = Inserterd("SQL", 2, ArticleAndKeywordFactory.sqls);
            java = Inserterd("Java", 4, ArticleAndKeywordFactory.javas);
            html = Inserterd("html", 5, ArticleAndKeywordFactory.uis);
        }

        private static Keyword Inserterd(string name, int counter, IList<ArticleAndKeyword> articles)
        {
            Keyword Keyword = new Keyword
            {
                Name = name,
                Counter = counter,
                Articles = articles
            };

            new BaseRepository<Keyword>(Global.context).Add(Keyword);

            return Keyword;
        }
    }
}
