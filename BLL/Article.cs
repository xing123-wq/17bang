using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int userId { get; set; }
        public Users Author { get; set; }
        public Series Series { get; set; }
        public Advertising Advertising { get; set; }
        public virtual IList<ArticleAndKeyword> Keywords { get; set; }
    }
}
