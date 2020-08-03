using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Chat
{
    public class ChatRoomModel
    {
        public int? CurrentUserId { get; set; }
        public IList<ChatItemModel> ChatRooms { get; set; }
    }
}
