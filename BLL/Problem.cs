﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Problem : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishTime { get; set; }
        public User Author { get; set; }
        public IList<ProblemAndKeyword> Keywords { get; set; }
    }
}
