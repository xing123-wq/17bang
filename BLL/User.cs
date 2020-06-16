﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public IList<Problem> Problems { get; set; }
        public IList<Article> Articles { get; set; }
    }
}
