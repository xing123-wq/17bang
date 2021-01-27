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
        public static Article SQL, JAVA, UI, RazorPage, Ajax, JavaScript, unity;
        public static IList<Article> Articles_1, Articles_2, Articles_3, Articles_4;

        internal static void Create()
        {

            SQL = Inserter(Global.Article_Title, Global.Article_Body, RegisterFactory.at, Global.Time.AddDays(1),
                            CategoryFactory.series1, ArticleAndKeywordFactory.javas, null, CommentFactory.comments2);

            JAVA = Inserter(Global.Article_Title, Global.Article_Body, RegisterFactory.at, Global.Time.AddDays(-1),
                            CategoryFactory.series1, ArticleAndKeywordFactory.sqls, null, CommentFactory.comments3);

            JAVA.InsertAfter(SQL);

            JavaScript = Inserter(Global.Article_Title, Global.Article_Body, RegisterFactory.lw, Global.Time.AddDays(-2),
                            CategoryFactory.series1, ArticleAndKeywordFactory.uis, null, CommentFactory.comments4);

            JavaScript.InsertAfter(JAVA);

            UI = Inserter(Global.Article_Title, Global.Article_Body, RegisterFactory.ht, Global.Time.AddDays(1),
                            CategoryFactory.series2, ArticleAndKeywordFactory.javas, null, CommentFactory.comments1
                            );

            UI.InsertAfter(JavaScript);

            RazorPage = Inserter(Global.Article_Title, Global.Article_Body, RegisterFactory.at, Global.Time.AddDays(-3),
                            CategoryFactory.series2, ArticleAndKeywordFactory.javas, null, CommentFactory.comments3);

            RazorPage.InsertAfter(UI);

            Ajax = Inserter(Global.Article_Title, Global.Article_Body, RegisterFactory.lzb, Global.Time.AddDays(-4),
                            CategoryFactory.series3, ArticleAndKeywordFactory.sqls, null, CommentFactory.comments2);

            Ajax.InsertAfter(RazorPage);

            unity = Inserter(Global.Article_Title, Global.Article_Body, RegisterFactory.wpz, Global.Time.AddDays(-5),
                            CategoryFactory.series3, ArticleAndKeywordFactory.uis, null, CommentFactory.comments3);

            unity.InsertAfter(Ajax);

            Articles_1 = new List<Article> { RazorPage, SQL, JAVA };
            Articles_2 = new List<Article> { UI, Ajax, unity };
            Articles_3 = new List<Article> { JavaScript };
            Articles_4 = new List<Article> { RazorPage, SQL, JAVA, unity, UI, Ajax, JavaScript };
        }

        public static Article Inserter(string title, string body, Users users, DateTime dateTime, Category category,
                                       IList<ArticleAndKeyword> keywords, AdInWidget widget,
                                       IList<Comment> comments)
        {
            Article article = new Article
            {
                Title = title,
                Body = body,
                Author = users,
                CreateTime = dateTime,
                Category = category,
                Keywords = keywords,
                AppraiseManager = new Appraise
                {
                    AgreeCount = 12,
                    DisagreeCount = 11
                },
                Advertising = widget,
                Comments = comments,
            };
            if (string.IsNullOrEmpty(article.Abstract))
            {
                article.Abstract = body.Substring(25);
            }


            new ArticleRepository(Global.context).Add(article);

            return article;
        }
    }
}
