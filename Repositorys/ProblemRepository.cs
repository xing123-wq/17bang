﻿using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class ProblemRepository : BaseRepository<Problem>
    {
        public ProblemRepository(SQLContext context) : base(context)
        {
        }
    }
}
