﻿using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Chat
{
    public class ChatItemModel : BaseModel
    {
        public string Content { get; set; }
        public int ChatAuthorId { get; set; }
        public string AuthorName { get; set; }
        public int? ReplyId { get; set; }
        public ChatItemModel Reply { get; set; }
    }
}
