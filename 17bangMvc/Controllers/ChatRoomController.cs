using ProdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Chat;

namespace _17bangMvc.Controllers
{
    public class ChatRoomController : BaseController
    {
        private ChatRoomService service;
        public ChatRoomController()
        {
            service = new ChatRoomService();
        }
        [HttpGet]
        public ActionResult Index(ChatRoomModel model)
        {
            model.CurrentUserId = service.CurrentUserId;
            model.ChatRooms = service.GetMessages();
            return View(model);
        }
        [HttpPost]
        public PartialViewResult _ReplyMessage(ChatItemModel model)
        {
            service.Save(model);
            return PartialView(model);
        }
        [HttpGet]
        public PartialViewResult _ReplyMessage(int id)
        {
            ChatItemModel model = new ChatItemModel();
            model = service.GetMessage(id);
            return PartialView(model);
        }
    }
}
