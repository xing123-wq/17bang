﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Comment : Content
    {
        public Comment Reply { get; set; }
        public override void Publish()
        {
            if (this.Author == Reply.Author)
            {
                throw new Exception("当前用户，不能回复自己的评论");
            }
            base.Publish();
        }
    }
}
