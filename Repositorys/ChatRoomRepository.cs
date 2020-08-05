﻿using BLL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repositorys
{
    public class ChatRoomRepository : BaseRepository<Chat>
    {
        public ChatRoomRepository(SQLContext context) : base(context)
        {
        }

        public IList<Chat> GetMessages()
        {
            return entities.Include(c => c.Author).Include(c => c.Reply).ToList();
        }

        public Chat GetMessage(int id)
        {
            return entities.Where(c => c.Id == id).Include(a => a.Author).Include(c => c.Reply).SingleOrDefault();
        }
    }
}
