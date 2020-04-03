using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp3
{
    public static class LinqWork
    {
        //在之前“文章/评价/评论/用户/关键字”对象模型的基础上，
        //添加相应的数据，然后完成以下操作：
        //找出“飞哥”发布的文章
        //找出2019年1月1日以后“小鱼”发布的文章
        //按发布时间升序/降序排列显示文章
        //统计每个用户各发布了多少篇文章
        //找出包含关键字“C#”或“.NET”的文章
        //找出评论数量最多的文章
        //声明一个委托：打水（ProvideWater），可以接受一个Person类的参数，返回值为int类型
        //使用方,匿名方,lambda表达式,给上述委托赋值，并运行该委托,
        //声明一个方法GetWater()，该方法接受ProvideWater作为参数，并能将ProvideWater的返回值输出

        static readonly User fg, xy;
        static Keyword sql, csharp, net, java, js, html;
        static readonly Article SQL, JAVA, UI, CSharp;
        static readonly Comment wx, atai, pzq, cbw, ljp;
        static LinqWork()
        {
            fg = new User { Name = "飞哥" };
            xy = new User { Name = "小余" };
            sql = new Keyword { Content = "SQL" };
            csharp = new Keyword { Content = "C#" };
            net = new Keyword { Content = ".NET" };
            java = new Keyword { Content = "JAVA" };
            js = new Keyword { Content = "JAVASCRIPT" };
            html = new Keyword { Content = "HTML" };
            SQL = new Article("文章")
            {
                Author = fg,
                Title = "SQL",
                Keywords = new List<Keyword> { sql }
            };
            JAVA = new Article("文章")
            {
                Author = fg,
                Title = "JAVA",
                Keywords = new List<Keyword> { java, html }
            };
            UI = new Article("文章")
            {
                Author = xy,
                Title = "UI",
                Keywords = new List<Keyword> { js, html, net }
            };
            CSharp = new Article("文章")
            {
                Author = xy,
                Title = "CSharp",
                Keywords = new List<Keyword> { csharp }
            };
            wx = new Comment(JAVA)
            {
                Body = "写的不行",
                Authors = new User
                {
                    Name = "王欣"
                }
            };
            atai = new Comment(SQL)
            {
                Body = "写的很好",
                Authors = new User
                {
                    Name = "阿泰"
                }
            };
            pzq = new Comment(UI)
            {
                Body = "还可以",
                Authors = new User
                {
                    Name = "彭志强"
                }
            };
            cbw = new Comment(CSharp)
            {
                Body = "一般般",
                Authors = new User
                {
                    Name = "陈百万"
                }
            };
            ljp = new Comment(CSharp)
            {
                Body = "看得下去",
                Authors = new User
                {
                    Name = "刘江平"
                }
            };
            SQL.Comments = new List<Comment> { atai };
            JAVA.Comments = new List<Comment> { wx };
            UI.Comments = new List<Comment> { pzq };
            CSharp.Comments = new List<Comment> { cbw, ljp };
            sql.Articles = new List<Article> { SQL };
            csharp.Articles = new List<Article> { CSharp };
            net.Articles = new List<Article> { UI };
            java.Articles = new List<Article> { JAVA };
            js.Articles = new List<Article> { UI };
            html.Articles = new List<Article> { JAVA, UI };
            articles = new List<Article> { SQL, JAVA, UI, CSharp };
            //ContentService.Publish(UI);
            //ContentService.Publish(CSharp);
            //ContentService.Publish(SQL);
            //ContentService.Publish(JAVA);
        }
        public static IEnumerable<Article> articles;
        public static void Do()
        {
            PublishArticleFg();
            PublishArticleXy();
            ArticleTime();
            UserArticle();
            GetKey(csharp, net);
            MaxComment();
            RecentlyArticle();
        }
        public static void PublishArticleFg()
        {
            Console.WriteLine("\n找出飞哥发布的文章:");
            var fgArticle = articles.Where(a => a.Author.Name == "飞哥");
            foreach (var item in fgArticle)
            {
                Console.WriteLine(item.Title);
            }

        }
        public static void PublishArticleXy()
        {
            Console.WriteLine("\n找出小余发布的文章:");
            var xyArtricle = articles.Where(a => a.Author == xy && a.PublishTime > new DateTime(2019, 1, 1));

            foreach (var item in xyArtricle)
            {
                Console.WriteLine(item.Title);
            }
        }
        public static void ArticleTime()
        {
            Console.WriteLine("\n按照时间升序降序显示文章:");
            var deta = articles.OrderByDescending(a => a.PublishTime);
            var Time = articles.OrderBy(a => a.PublishTime);

            foreach (var item in deta)
            {
                Console.WriteLine(item.Title);
            }
            foreach (var item in Time)
            {
                Console.WriteLine(item.Title);
            }
        }
        public static void UserArticle()
        {
            Console.WriteLine("\n统计每个用户各发布了多少篇文章");
            var authorArticle = articles.GroupBy(a => a.Author)
                .Select(gm => new
                {
                    Author = gm.Key,
                    count = gm.Count()
                });
            foreach (var item in authorArticle)
            {
                Console.WriteLine(item.Author.Name + ":" + item.count);
            }
        }
        public static void GetKey(Keyword keyword, Keyword Keyword)
        {
            Console.WriteLine("\n找出包含关键字“C#”或“.NET”的文章");
            var SeekKey = articles.Where(a => a.Keywords.Contains(keyword) || a.Keywords.Contains(Keyword));
            foreach (var item in SeekKey)
            {
                Console.WriteLine($"{item.Author.Name}:{ item.Title}");
            }
        }
        public static void MaxComment()
        {
            Console.WriteLine("\n找出评论数量最多的文章:");
            var ArticleComment = (articles.OrderByDescending(a => a.Comments.Count()).First());
            Console.WriteLine(ArticleComment.Title);
        }
        //将之前作业的Linq查询表达式用Linq方法实现
        //找出每个作者最近发布的一篇文章
        //为求助（Problem）添加悬赏（Reward）属性，并找出每一篇求助的悬赏都大于5个帮帮币的文章作者
        public static void RecentlyArticle()
        {
            Console.WriteLine("\n找出每个作者最近发布的一篇文章");
            var recently = articles.GroupBy(a => a.Author)
                .Select(a => a.OrderByDescending
                (p => p.PublishTime).First());
            foreach (var item in recently)
            {
                Console.WriteLine(item.Title);
            }
        }
    }
}
