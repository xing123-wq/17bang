﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Problem : Content
    {
        public IList<ProblemAndKeyword> Keywords { get; set; }
    }
}
