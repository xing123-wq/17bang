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
        static KeywordFactory()
        {
            sql = new Keyword { Articles = ArticleAndKeywordFactory.sqls, Name = "SQL" };
            java = new Keyword { Articles = ArticleAndKeywordFactory.javas, Name = "java" };
            html = new Keyword { Articles = ArticleAndKeywordFactory.uis, Name = "html" };
        }
        public static void Create()
        {
            IList<Keyword> keywords = new List<Keyword> { sql, java, html };
            new BaseRepository<Keyword>(Global.context).AddRange(keywords);
        }
    }
}
