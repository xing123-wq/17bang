using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class Comment : IAppraise
    {
        public string Body { get; set; }
        private readonly Article _article;
        public User Author { get; set; }
        public IList<Appraise> Appraises { get; set; }
        public DateTime PublishDateTime { get; set; }
        public Comment(Article article)//记录文章
        {
            this._article = article;
        }
        public Comment()
        {
            if (_article == null)
            {
                throw new NullReferenceException("不能没有文章，发布评论");
            }
            //else do nothing
        }
        public void Agree(User voter)
        {
            voter.HelpMony += 1;
        }
        public void Disagree(User voter)
        {
            voter.HelpMony -= 1;
        }
    }
}
