using BLL;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFactory
{
    class ArticleFactory
    {
        public static Article SQL, JAVA, UI;
        static IList<Article> articles;
        static ArticleFactory()
        {
            SQL = new Article
            {
                Title = "什么是SQL?",
                Content = "SQL是数据库",
                Author = RegisterFactory.at,
                PublishTime = Global.Time.AddDays(1),
                Advertising = null,
                Series = null,
                Keywords = ArticleAndKeywordFactory.sqls
            };
            JAVA = new Article
            {
                Title = "什么是JAVA?",
                Content = "JAVA是一种语言",
                Author = RegisterFactory.wpz,
                PublishTime = Global.Time.AddDays(-1),
                Advertising = null,
                Series = null,
                Keywords = ArticleAndKeywordFactory.javas
            }; UI = new Article
            {
                Title = "什么是UI?",
                Content = "UI是HTML等组成的统称",
                Author = RegisterFactory.lzb,
                PublishTime = Global.Time.AddDays(2),
                Advertising = null,
                Series = null,
                Keywords = ArticleAndKeywordFactory.uis
            };
        }
        internal static void Create()
        {
            articles = new List<Article> { SQL, JAVA, UI };
            new ArticleRepository(Global.context).AddRange(articles);
        }
    }
}
