using ConsoleApp3;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace _17bangTests
{
    public class LinqTest
    {
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
        public static Article SQL, JAVA, UI, CSharp;
        /// <summary>
        /// 评论
        /// </summary>
        public static Comment wx, atai, pzq, cbw, ljp;
        /// <summary>
        /// 文章集合
        /// </summary>
        public static IEnumerable<Article> articles;
        [SetUp]
        public void LinqSetup()
        {
            fg = new User(1, "飞哥");
            xy = new User(2, "小余");
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
                Keywords = new List<Keyword> { sql },
                PublishDateTime = new DateTime(2020, 3, 3),
                Comments = new List<Comment> { wx, cbw, pzq },
                Id = 1
            };
            JAVA = new Article("文章")
            {
                Author = xy,
                Title = "JAVA",
                Keywords = new List<Keyword> { java, html },
                Comments = new List<Comment> { wx, atai, pzq },
                PublishDateTime = new DateTime(2019, 5, 3)
            };
            UI = new Article("文章")
            {
                Author = fg,
                Title = "UI",
                Comments = new List<Comment> { wx, cbw, pzq, atai },
                PublishDateTime = new DateTime(2020, 10, 1),
                Keywords = new List<Keyword> { js, html, net }
            };
            CSharp = new Article("文章")
            {
                Author = xy,
                Title = "CSharp",
                PublishDateTime = new DateTime(2019, 1, 1),
                Comments = new List<Comment> { wx, cbw, pzq },
                Keywords = new List<Keyword> { csharp }
            };

            wx = new Comment()
            {
                PublishDateTime = new DateTime(2020, 12, 30),
                Body = "写的不行",
                Authors = new User(3, "王欣")
            };
            atai = new Comment(SQL)
            {
                PublishDateTime = new DateTime(2020, 2, 20),
                Body = "写的很好",
                Authors = new User(4, "阿泰")
            };
            pzq = new Comment(UI)
            {
                PublishDateTime = new DateTime(2020, 4, 8),
                Body = "还可以",
                Authors = new User(5, "彭志强"),
            };
            cbw = new Comment(CSharp)
            {
                PublishDateTime = new DateTime(2020, 3, 19),
                Body = "一般般",
                Authors = new User(6, "陈百万"),
            };
            ljp = new Comment(CSharp)
            {
                PublishDateTime = new DateTime(2020, 5, 3),
                Body = "看得下去",
                Authors = new User(7, "刘江平"),
            };
            articles = new List<Article> { SQL, JAVA, UI, CSharp };
        }

        [Test]
        public void SetupCorrectLinq()
        {
            Assert.NotNull(articles);
        
        }

        [Test]
        public void PublishArticleFgTest()
        {

        }


    }
}

