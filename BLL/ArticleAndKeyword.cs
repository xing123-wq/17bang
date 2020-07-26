using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ArticleAndKeyword : BaseEntity
    {
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
        public int KeywordId { get; set; }
        public virtual Keyword Keyword { get; set; }
    }
}
