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
        public DateTime PublishTime { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public Series Series { get; set; }
        public Advertising Advertising { get; set; }
        public IList<ArticleAndKeyword> Keywords { get; set; }
    }
}
