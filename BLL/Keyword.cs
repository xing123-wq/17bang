using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Keyword : BaseEntity
    {
        public string Name { get; set; }
        public int Counter { get; set; }
        public IList<ArticleAndKeyword> Articles { get; set; }
        public IList<ProblemAndKeyword> Problems { get; set; }
    }
}
