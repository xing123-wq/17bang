using BLL;
using Repositorys;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Chat;

namespace ProdService
{
    public class ChatRoomService : BaseService, IChatRoomService
    {
        private ChatRoomRepository repository;
        public ChatRoomService()
        {
            repository = new ChatRoomRepository(context);
        }
        public string GetAuthorName()
        {
            Users user = GetByCurrentUser();
            return user.Name;
        }

        public IList<ChatItemModel> GetMessages(int id)
        {
            IList<Chat> chats = repository.GetMessages(id);
            return mapper.Map<IList<ChatItemModel>>(chats);
        }

        public ChatItemModel GetMessage(int id)
        {
            Chat chat = repository.GetMessage(id);
            return mapper.Map<ChatItemModel>(chat);
        }

        public int Save(ChatItemModel model)
        {
            Chat chat = mapper.Map<Chat>(model);
            chat.PublishTime = DateTime.Now;
            chat.Author = GetByCurrentUser();
            repository.Add(chat);
            return chat.Id;
        }
    }
}
