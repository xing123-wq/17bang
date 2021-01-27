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
        private readonly ChatRoomRepository _repository;
        public ChatRoomService()
        {
            _repository = new ChatRoomRepository(Context);
        }
        public string GetAuthorName()
        {
            return GetByCurrentUser().Name;
        }

        public IList<ChatItemModel> GetMessages(int id)
        {
            var chats = _repository.GetMessages(id);
            return Mapper.Map<IList<ChatItemModel>>(chats);
        }

        public ChatItemModel GetMessage(int id)
        {
            var chat = _repository.GetMessage(id);
            return Mapper.Map<ChatItemModel>(chat);
        }

        public int Save(ChatItemModel model)
        {
            var chat = Mapper.Map<Chat>(model);
            chat.CreateTime = DateTime.Now;
            chat.Author = GetByCurrentUser();
            _repository.Add(chat);
            return chat.Id;
        }
    }
}
