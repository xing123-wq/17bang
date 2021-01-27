using BLL;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFactory
{
    class CommentFactory
    {
        public static Comment comment1, comment2, comment3, comment4;
        public static IList<Comment> comments1, comments2, comments3, comments4;

        public static void Create()
        {
            foreach (var item in ArticleFactory.Articles_4)
            {
                comment1 = Inserted(Global.comment_article1, null, RegisterFactory.at, item);
                comment2 = Inserted(Global.comment_article2, comment1, RegisterFactory.lw, item);
                comment3 = Inserted(Global.comment_article3, comment2, RegisterFactory.lzb, item);
                comment4 = Inserted(Global.comment_article4, comment4, RegisterFactory.ht, item);
            }

            comments1 = new List<Comment> { comment1, comment2, comment3 };
            comments2 = new List<Comment> { comment2, comment4, comment1, comment4 };
            comments3 = new List<Comment> { comment1, comment2, comment3 };
            comments4 = new List<Comment> { comment1, comment2, comment3, comment4 };
        }

        private static Comment Inserted(string body, Comment reply, Users users, Article article)
        {
            Comment comment = new Comment
            {
                Body = body,
                Reply = reply,
                Author = users,
                Article = article
            };

            new BaseRepository<Comment>(Global.context).Add(comment);

            return comment;
        }
    }
}
