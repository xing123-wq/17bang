using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProblemAndKeyword : BaseEntity
    {
        public int ProblemId { get; set; }
        public Problem Problem { get; set; }
        public int KeywordId { get; set; }
        public Keyword Keyword { get; set; }
    }
}
