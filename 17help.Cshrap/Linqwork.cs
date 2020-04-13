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

        /// <summary>
        /// 用户
        /// </summary>
        public static User fg, xy;
        /// <summary>
        /// 关键字
        /// </summary>
        public static Keyword sql, csharp, net, java, js, html;
        /// <summary>
        /// 文章
        /// </summary>
        public static Article SQL, JAVA, UI, CSharp, NET;
        /// <summary>
        /// 评论
        /// </summary>
        public static Comment wx, atai, pzq, cbw, ljp, wmz, dfg;
        /// <summary>
        /// 点赞点踩
        /// </summary>
        public static Appraise AppraiseorNot, AppraiseorNot1, AppraiseorNot2, AppraiseorNot3, AppraiseorNot4;
        /// <summary>
        /// 求助
        /// </summary>
        public static Problem problem1, problem2, problem3, problem4;
        /// <summary>
        /// 求助集合
        /// </summary>
        public static IEnumerable<Problem> Problems;
        /// <summary>
        /// 文章集合
        /// </summary>
        public static IEnumerable<Article> articles;
        public static IEnumerable<Keyword> Keywords;
        static LinqWork()
        {
            fg = new User { Id = 1, Name = "飞哥", HelpMony = 12 };
            xy = new User { Id = 2, Name = "小余", HelpMony = 11 };
            sql = new Keyword { Id = 1, Name = "SQL" };
            csharp = new Keyword { Id = 2, Name = "C#" };
            net = new Keyword { Id = 3, Name = ".NET" };
            java = new Keyword { Id = 4, Name = "JAVA" };
            js = new Keyword { Id = 5, Name = "JAVASCRIPT" };
            html = new Keyword { Id = 6, Name = "HTML" };
            SQL = new Article("文章")
            {
                Id = 1,
                Author = fg,
                Body = "SQL1",
                Title = "SQL",
                Keywords = new List<Keyword> { sql },
                PublishDateTime = new DateTime(2020, 3, 3),
                Comments = new List<Comment> { wx, dfg },
            };
            JAVA = new Article("文章")
            {
                Id = 2,
                Author = xy,
                Title = "JAVA",
                Body = "java1",
                Keywords = new List<Keyword> { java, html },
                Comments = new List<Comment> { atai },
                PublishDateTime = new DateTime(2019, 5, 3),
            };
            UI = new Article("文章")
            {
                Id = 3,
                Title = "UI",
                Author = fg,
                Body = "ui操作",
                Comments = new List<Comment> { pzq },
                PublishDateTime = new DateTime(2020, 10, 1),
                Keywords = new List<Keyword> { js, html, net },
            };
            CSharp = new Article("文章")
            {
                Id = 5,
                Title = "csharp",
                Author = xy,
                Body = "C#操作",
                PublishDateTime = new DateTime(2019, 1, 1),
                Comments = new List<Comment> { cbw, wmz },
                Keywords = new List<Keyword> { csharp },
            };
            NET = new Article("文章")
            {
                Id = 6,
                Title = "net",
                Author = fg,
                Body = ".NET操作",
                PublishDateTime = new DateTime(2020, 10, 5),
                Comments = new List<Comment> { ljp },
                Keywords = new List<Keyword> { net, csharp, sql },
            };

            wx = new Comment(UI)
            {
                PublishDateTime = new DateTime(2020, 12, 30),
                Body = "写的不行",
                Authors = new User { Id = 3, Name = "王欣", HelpMony = 8 }
            };
            atai = new Comment(SQL)
            {
                PublishDateTime = new DateTime(2020, 2, 20),
                Body = "写的很好",
                Authors = new User { Id = 4, Name = "阿泰", HelpMony = 100 }

            };
            pzq = new Comment(JAVA)
            {
                PublishDateTime = new DateTime(2020, 4, 8),
                Body = "还可以",
                Authors = new User { Id = 5, Name = "陈百万", HelpMony = 7 }

            };
            cbw = new Comment(NET)
            {
                PublishDateTime = new DateTime(2020, 3, 19),
                Body = "一般般",
                Authors = new User { Id = 6, Name = "刘江平", HelpMony = 4 }

            };
            ljp = new Comment(CSharp)
            {
                PublishDateTime = new DateTime(2020, 5, 3),
                Body = "看得下去",
                Authors = new User { Id = 7, Name = "王明智", HelpMony = 8 }

            };
            wmz = new Comment(CSharp)
            {
                PublishDateTime = new DateTime(2019, 3, 5),
                Body = "这样的你不行",
                Authors = new User { Id = 8, Name = "大飞哥", HelpMony = 3 }

            };
            dfg = new Comment(SQL)
            {
                PublishDateTime = new DateTime(2019, 12, 30),
                Body = "写的没我好",
                Authors = new User { Id = 9, Name = "赵淼", HelpMony = 2 }
            };

            SQL.Comments = new List<Comment> { atai, dfg };
            JAVA.Comments = new List<Comment> { wx };
            UI.Comments = new List<Comment> { pzq };
            CSharp.Comments = new List<Comment> { cbw, ljp };
            sql.Articles = new List<Article> { SQL };
            csharp.Articles = new List<Article> { CSharp, NET };
            net.Articles = new List<Article> { UI };
            java.Articles = new List<Article> { JAVA, SQL };
            js.Articles = new List<Article> { UI };
            html.Articles = new List<Article> { JAVA, UI };
            articles = new List<Article> { SQL, JAVA, UI, CSharp, NET };
            Keywords = new List<Keyword> { sql, java, js, net, html, csharp };

            problem1 = new Problem
            {
                PublishDateTime = new DateTime(2020, 2, 1),
                Author = fg,
                Reward = 21,
                Body = "期望功能：当U盘被拔下后，系统崩溃或者退出。" +
                "经历：之前看到别人做过，按我正常的理解，系统本身会有检查U盘存在与否的功能，" +
                "但是别人并没有这样做，也就是说他并没有动系统的代码，而是直接对程序一通操作，" +
                "然后就加密了。哪位大神有相关经验或者思路，求一个——————……",
                Title = " 如何使用U盘防护系统的运行",
                Keywords = new List<Keyword>
                {
                   sql,java,csharp
                },
            };
            problem2 = new Problem
            {
                PublishDateTime = new DateTime(2019, 10, 7),
                Author = fg,
                Reward = 1,
                Body = "……",
                Title = " 为什么在给变量a赋值后，再使a=a++之后，输出a的值没有变化。",
                Keywords = new List<Keyword>
                {
                   java,csharp,js
                },
            };
            problem3 = new Problem
            {
                PublishDateTime = new DateTime(2020, 1, 21),
                Author = xy,
                Reward = 22,
                Body = "RT，也不知道描述的清楚不清楚。求一个思路……c",
                Title = " 有一个自定义UI控件，此控件使用在不同的系统中会有不同的呈现，" +
                "之前的做法是各种switch case，阅读代码时让人很难受，另外新创建一个用到此控件的系统，" +
                "要修改代码的地方也多，只要有swich case 的地方都要再加一个case。" +
                "请教一个好一些的方式来处理这个问题，目的是让代码更加清楚",
                Keywords = new List<Keyword>
                {
                    net,html,sql
                }
            };
            problem4 = new Problem
            {
                PublishDateTime = new DateTime(219, 2, 4),
                Author = fg,
                Reward = 5,
                Body = "数据库操作",
                Title = "SQLsever",
                Keywords = new List<Keyword>
                {
                    csharp,html,net
                }
            };
            Problems = new List<Problem> { problem1, problem2, problem3, problem4 };
            ContentService.Publish(CSharp);
            ContentService.Publish(SQL);
            ContentService.Publish(NET);
            ContentService.Publish(JAVA);
            ContentService.Publish(UI);
        }
        public static void Do()
        {
            PublishArticleFg();
            PublishArticleXy();
            ArticleTime();
            UserArticle();
            GetKey();
            MaxComment();
            RecentlyArticle();
            SelectRewar();
            LinqSelect();
            MaxArticle();
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
            var xyArtricle = articles.Where(a => a.Author == xy && a.PublishDateTime > new DateTime(2019, 1, 1));

            foreach (var item in xyArtricle)
            {
                Console.WriteLine(item.Title);
            }
        }
        public static void ArticleTime()
        {
            Console.WriteLine("\n按照时间升序降序显示文章:");
            var deta = articles.OrderByDescending(a => a.PublishDateTime);
            foreach (var item in deta)
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
        public static void GetKey()
        {
            Console.WriteLine("\n找出包含关键字“C#”或“.NET”的文章");
            var SeekKey = articles.Where(a => a.Keywords.Any(a => a.Name == "C#") || a.Keywords.Any(a => a.Name == ".NET"));
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
                (p => p.PublishDateTime).First());
            foreach (var item in recently)
            {
                Console.WriteLine($"{item.Author.Name}:{item.Title}");
            }
        }
        public static void MaxArticle()
        {
            Console.WriteLine("-----------------");
            var max = articles.GroupBy(a => a.Author)
                .Select(a => a.OrderByDescending(c => c.Comments.Count()).First());
            foreach (var item in max)
            {
                Console.WriteLine($"{item.Author.Name}:{item.Title}");
            }
        }
        public static void SelectRewar()
        {
            Console.WriteLine("\n找出悬赏大于5的求助");
            var rewar = Problems.Where(p => p.Reward > 5);
            foreach (var item in rewar)
            {
                Console.WriteLine($"{item.Author.Name}:{item.Title}:{item.Reward}");
            }
        }
        public static void LinqSelect()
        {
            //找出“飞哥”发布的文章
            var selectfg = from s in articles
                           where s.Author.Name == fg.Name
                           select s;
            foreach (var item in selectfg)
            {
                Console.WriteLine($"{item.Author.Name}:{item.Title}");
            }
            //找出2019年1月1日以后“小鱼”发布的文章
            var selectxy = from s in articles
                           where s.Author.Name == xy.Name &&
                           s.PublishDateTime > new DateTime(2019, 1, 1)
                           select s;
            foreach (var xy in selectxy)
            {
                Console.WriteLine($"{xy.Author.Name}:{xy.Title}:{xy.PublishDateTime}");
            }
            //按发布时间升序/降序排列显示文章
            var ascending = from a in articles
                            orderby a.PublishDateTime ascending //descending
                            select a;
            foreach (var article in ascending)
            {
                Console.WriteLine(article.Title);
            }
            //统计每个用户各发布了多少篇文章
            var maxarticle = from a in articles
                             group a by a.Author.Name into gm
                             select new
                             {
                                 Author = gm.Key,
                                 count = gm.Count()
                             };

            foreach (var m in maxarticle)
            {
                Console.WriteLine($"{m.Author }:{m.count}");
            }

            //找出包含关键字“C#”或“.NET”的文章
            var keyword = from a in articles
                          where a.Keywords.Any(k => k.Name == "C#") || a.Keywords.Any(k => k.Name == ".NET")
                          select a;
            foreach (var item in keyword)
            {
                Console.WriteLine(item.Title);
            }

            //找出评论数量最多的文章
            var slectcomment = (from c in articles
                                orderby c.Comments.Count() descending
                                select c).First();
            Console.WriteLine($"{ slectcomment.Title}:{slectcomment.Comments.Count()}");

            //找出每个作者评论最多的文章
            Console.WriteLine("-------------");
            var selectcomment = from a in articles
                                orderby a.Comments.Count() descending
                                group a by a.Author into ga
                                select new
                                {
                                    author = ga.Key,
                                    comment = ga.First()
                                };
            foreach (var item in selectcomment)
            {
                Console.WriteLine($"{item.author.Name}:{item.comment.Title}:{item.comment.Comments.Count()}");
            }
            var selectrecently = from a in articles
                                 orderby a.PublishDateTime descending
                                 group a by a.Author into ga
                                 select new
                                 {
                                     author = ga.Key,
                                     publish = ga.First()
                                 };

            foreach (var item in selectrecently)
            {
                Console.WriteLine($"{item.author.Name}:{item.publish.Title}:{item.publish.PublishDateTime}");
            }
        }
    }
}
