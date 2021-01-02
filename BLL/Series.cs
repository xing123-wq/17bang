using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Series : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public Users Author { get; set; }
        public Series Parent { get; set; }
        public bool IsDefault { get; set; }
        public IList<Article> Articles { get; set; }
    }
}
