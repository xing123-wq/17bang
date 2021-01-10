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
        static ArticleFactory()
        {
            SQL = new Article
            {
                Title = "什么是SQL?",
                Content = "SQL是数据库",
                Author = RegisterFactory.at,
                PublishTime = Global.Time.AddDays(1),
                Series = SeriesFactory.series1,
                Keywords = ArticleAndKeywordFactory.sqls
            };
            JAVA = new Article
            {
                Title = "什么是JAVA?",
                Content = "JAVA是一种语言",
                Author = RegisterFactory.wpz,
                PublishTime = Global.Time.AddDays(-1),
                Series = SeriesFactory.series2,
                Keywords = ArticleAndKeywordFactory.javas
            };
            UI = new Article
            {
                Title = "什么是UI?",
                Content = "UI是HTML等组成的统称",
                Author = RegisterFactory.lzb,
                PublishTime = Global.Time.AddDays(2),
                Series = SeriesFactory.series3,
                Keywords = ArticleAndKeywordFactory.uis
            };

        }
        internal static void Create()
        {
            ArticleRepository repository = new ArticleRepository(Global.context);
            repository.AddRange(new List<Article> { SQL, JAVA, UI });
            SQL.InsertAfter(JAVA);
            JAVA.InsertAfter(UI);
        }
    }
}
