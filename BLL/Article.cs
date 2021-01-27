using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Article : Content, IDoubleLinked<Article>
    {
        public Category Category { get; set; }
        public Article Next { get; set; }
        public Article Previous { get; set; }
        public string Abstract { get; set; }
        public AdInWidget Advertising { get; set; }
        public virtual Appraise AppraiseManager { get; set; }
        public string Title { get; set; }
        public IList<ArticleAndKeyword> Keywords { get; set; }
        public IList<Comment> Comments { get; set; }
        public void EditOrPublish(string keyword)
        {
            Keywords = new ArticleAndKeyword().GetString(keyword);
            base.EditOrPublish();
        }

        public void InsertAfter(Article node)
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
