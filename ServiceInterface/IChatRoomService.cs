using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Chat;

namespace ServiceInterface
{
    public interface IChatRoomService : IBaseService
    {
        int Save(ChatItemModel model);
        ChatItemModel GetMessage(int id);
        IList<ChatItemModel> GetMessages(int id);
    }
}
