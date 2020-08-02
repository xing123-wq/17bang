using BLL;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Chat;

namespace ProdService
{
    public class ChatRoomService : BaseService
    {
        private ChatRoomRepository repository;
        public ChatRoomService()
        {
            repository = new ChatRoomRepository(context);
        }
        public string GetAuthorName()
        {
            User user = GetByCurrentUser();
            return user.Name;
        }

        public IList<ChatItemModel> GetMessages()
        {
            IList<Chat> chats = repository.GetMessages();
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
