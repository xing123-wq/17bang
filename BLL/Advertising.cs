using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Advertising : BaseEntity
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime PublishTime { get; set; }
        public DateTime Expires { get; set; }
        public int AuthorId { get; set; }
        public Users Author { get; set; }
        public IList<Article> Articles { get; set; }
    }
}
