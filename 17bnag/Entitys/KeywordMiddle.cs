using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bnag.Entitys
{
    public class KeywordMiddle
    {
        public int HelpreleaseId { get; set; }
        public HelpRelease HelpReleases { get; set; }
        public int KeywordId { get; set; }
        public Keyword Keywords { get; set; }
    }
}
