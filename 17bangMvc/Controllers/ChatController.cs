using ProdService;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Chat;

namespace _17bangMvc.Controllers
{
    public class ChatController : BaseController
    {
        private IChatRoomService service;
        public ChatController(IChatRoomService service)
        {
            this.service = service;
        }
        [HttpPost]
        public ActionResult Room(ChatItemModel model)
        {
            int id = service.Save(model);
            return Redirect($"/Chat/Room?id={id}");
        }
        [HttpGet]
        public ActionResult Room(int id = 0)
        {
            ChatRoomModel model = new ChatRoomModel();
            model.CurrentUserId = service.CurrentUserId;
            model.ChatRooms = service.GetMessages(id);
            return View(model);
        }
    }
}
