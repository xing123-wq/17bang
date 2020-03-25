using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bnag.Entitys
{
    public class KeywordMiddle
    {
        public int HelpReleaseId { get; set; }
        public HelpRelease HelpRelease { get; set; }
        public int KeywordId { get; set; }
        public Keyword Keyword { get; set; }

    }
}
