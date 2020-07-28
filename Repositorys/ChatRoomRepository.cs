using BLL;
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

        public IList<Chat> Get()
        {
            return entities.Include(c=>c.Author).ToList();
        }
    }
}
