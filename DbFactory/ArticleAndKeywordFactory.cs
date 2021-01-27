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

        public static void Create()
        {
            sql = Inserterd(KeywordFactory.sql.Id, KeywordFactory.sql, ArticleFactory.SQL, ArticleFactory.SQL.Id);
            java = Inserterd(KeywordFactory.java.Id, KeywordFactory.java, ArticleFactory.JAVA, ArticleFactory.JAVA.Id);
            ui = Inserterd(KeywordFactory.html.Id, KeywordFactory.html, ArticleFactory.UI, ArticleFactory.UI.Id);

            sqls = new List<ArticleAndKeyword> { sql };
            javas = new List<ArticleAndKeyword> { java };
            uis = new List<ArticleAndKeyword> { ui };

        }

        private static ArticleAndKeyword Inserterd(int keywordId, Keyword keyword, Article article, int articleId)
        {
            ArticleAndKeyword articleAndKeyword = new ArticleAndKeyword
            {
                ArticleId = articleId,
                Article = article,
                KeywordId = keywordId,
                Keyword = keyword
            };

            new BaseRepository<ArticleAndKeyword>(Global.context).Add(articleAndKeyword);

            return articleAndKeyword;
        }


    }
}
