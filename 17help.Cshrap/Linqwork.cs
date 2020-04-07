﻿using System;
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
        public static Comment wx, atai, pzq, cbw, ljp;
        /// <summary>
        /// 点赞点踩
        /// </summary>
        public static Appraise AppraiseorNot, AppraiseorNot1, AppraiseorNot2, AppraiseorNot3, AppraiseorNot4;
        public static IEnumerable<Article> articles;
        static LinqWork()
        {
            fg = new User(1, "飞哥");
            xy = new User(2, "小余");
            sql = new Keyword { Id = 1, Name = "SQL" };
            csharp = new Keyword { Id = 2, Name = "C#" };
            net = new Keyword { Id = 3, Name = ".NET" };
            java = new Keyword { Id = 4, Name = "JAVA" };
            js = new Keyword { Id = 5, Name = "JAVASCRIPT" };
            html = new Keyword { Id = 6, Name = "HTML" };
            AppraiseorNot = new Appraise { AgreeNumber = 12, NotNumber = 1 };
            AppraiseorNot1 = new Appraise { AgreeNumber = 3, NotNumber = 12 };
            AppraiseorNot2 = new Appraise { AgreeNumber = 23, NotNumber = 10 };
            AppraiseorNot3 = new Appraise { AgreeNumber = 32, NotNumber = 4 };
            AppraiseorNot4 = new Appraise { AgreeNumber = 12, NotNumber = 32 };
            SQL = new Article("文章")
            {
                Id = 1,
                Author = fg,
                Body = "SQL1",
                Title = "SQL",
                Keywords = new List<Keyword> { sql },
                PublishDateTime = new DateTime(2020, 3, 3),
                Comments = new List<Comment> { wx, cbw, pzq },
                Appraises = new List<Appraise> { AppraiseorNot2 }
            };
            JAVA = new Article("文章")
            {
                Id = 2,
                Author = xy,
                Title = "JAVA",
                Body = "java1",
                Keywords = new List<Keyword> { java, html },
                Comments = new List<Comment> { wx, atai, pzq },
                PublishDateTime = new DateTime(2019, 5, 3),
                Appraises = new List<Appraise> { AppraiseorNot }
            };
            UI = new Article("文章")
            {
                Id = 3,
                Title = "UI",
                Author = fg,
                Body = "ui操作",
                Comments = new List<Comment> { wx, cbw, pzq, atai },
                PublishDateTime = new DateTime(2020, 10, 1),
                Keywords = new List<Keyword> { js, html, net },
                Appraises = new List<Appraise> { AppraiseorNot1 }
            };
            CSharp = new Article("文章")
            {
                Id = 5,
                Title = "CSharp",
                Author = xy,
                Body = "C#操作",
                PublishDateTime = new DateTime(2019, 1, 1),
                Comments = new List<Comment> { wx, cbw, pzq },
                Keywords = new List<Keyword> { csharp },
                Appraises = new List<Appraise> { AppraiseorNot4 }
            };
            NET = new Article("文章")
            {
                Id = 6,
                Title = ".NET",
                Author = fg,
                Body = ".NET操作",
                PublishDateTime = new DateTime(2020, 10, 5),
                Comments = new List<Comment> { wx, atai, cbw, ljp },
                Keywords = new List<Keyword> { net, csharp, sql },
                Appraises = new List<Appraise> { AppraiseorNot3 }
            };

            wx = new Comment(UI)
            {
                PublishDateTime = new DateTime(2020, 12, 30),
                Body = "写的不行",
                Authors = new User(3, "王欣"),
                Appraises = new List<Appraise> { AppraiseorNot1 }
            };
            atai = new Comment(SQL)
            {
                PublishDateTime = new DateTime(2020, 2, 20),
                Body = "写的很好",
                Authors = new User(4, "阿泰"),
                Appraises = new List<Appraise> { AppraiseorNot2 }
            };
            pzq = new Comment(UI)
            {
                PublishDateTime = new DateTime(2020, 4, 8),
                Body = "还可以",
                Authors = new User(5, "彭志强"),
                Appraises = new List<Appraise> { AppraiseorNot3 }
            };
            cbw = new Comment(CSharp)
            {
                PublishDateTime = new DateTime(2020, 3, 19),
                Body = "一般般",
                Authors = new User(6, "陈百万"),
                Appraises = new List<Appraise> { AppraiseorNot4 }
            };
            ljp = new Comment(CSharp)
            {
                PublishDateTime = new DateTime(2020, 5, 3),
                Body = "看得下去",
                Authors = new User(7, "刘江平"),
                Appraises = new List<Appraise> { AppraiseorNot2 }
            };
            articles = new List<Article> { SQL, JAVA, UI, CSharp, NET };
        }
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
                (p => p.PublishDateTime).First());
            foreach (var item in recently)
            {
                Console.WriteLine(item.Title);
            }
        }
    }
}
