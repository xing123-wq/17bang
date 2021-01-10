using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Article : BaseEntity, IDoubleLinked<Article>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Users Author { get; set; }
        public Series Series { get; set; }

        public Article Next { get; set; }
        public Article Previous { get; set; }

        public Advertising Advertising { get; set; }
        public virtual IList<ArticleAndKeyword> Keywords { get; set; }
        public void Publish(string keyword)
        {
            PublishTime = DateTime.Now;
            Keywords = new ArticleAndKeyword().GetString(keyword);
        }
        public virtual void InsertAfter(Article node)
        {
            if (node?.Id == Id)
            {
                throw new ArgumentException($"不能将自己（id={Id}）插入自己之后");
            }
            DLTookit<Article> tookit = new DLTookit<Article>(this);
            tookit.InsertAfter(node);
        }
    }
}
