﻿using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class CommentRepository : BaseRepository<Comment>
    {
        public CommentRepository(SqlContext context) : base(context)
        {
        }
    }
}
