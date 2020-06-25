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
        public User User { get; set; }
        public IList<Article> Articles { get; set; }
    }
}
