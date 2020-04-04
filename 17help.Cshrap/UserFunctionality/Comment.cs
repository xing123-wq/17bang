using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class Comment : IAppraise
    {
        public string Body { get; set; }
        private Article _article;

        public User Authors { get; set; }
        public IList<Appraise> Appraises { get; set; }
        public Article Articles { get; set; }
        public Comment(Article article)//记录文章
        {
            this._article = article;
            if (_article != null)
            {
                new Article();
            }
            else
            {
                Console.WriteLine("每个评论，不能没有文章生成！");
            }
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
