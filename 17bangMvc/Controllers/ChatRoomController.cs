using ProdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Chat;

namespace _17bangMvc.Controllers
{
    public class ChatRoomController : Controller
    {
        private ChatRoomService service;
        public ChatRoomController()
        {
            service = new ChatRoomService();
        }
        [HttpGet]
        public PartialViewResult Index()
        {
            ChatRoomModel model = new ChatRoomModel();
            model.ChatRooms = service.GetMessages();
            return PartialView(model);
        }
        [HttpPost]
        public PartialViewResult Index(ChatItemModel model)
        {
            service.Save(model);
            return PartialView(model);
        }
    }
}
