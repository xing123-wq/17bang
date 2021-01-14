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
        public Series Series { get; set; }
        public Article Next { get; set; }
        public Article Previous { get; set; }
        public string Abstract { get; set; }
        public Advertising Advertising { get; set; }
        public virtual Appraise AppraiseManager { get; set; }

        public virtual IList<ArticleAndKeyword> Keywords { get; set; }
        public virtual void Publish(string keyword)
        {
            if (string.IsNullOrEmpty(this.Abstract))
            {
                this.Abstract = this.Body.Substring(15);
            }
            
            Keywords = new ArticleAndKeyword().GetString(keyword);
            
            base.Publish();
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
