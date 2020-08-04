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
        public ActionResult Index(ChatItemModel model)
        {
            if (model.Reply != null)
            {
                model.Reply = service.GetMessage(model.Reply.Id);
            }
            int id = service.Save(model);
            return Redirect($"/ChatRoom/index?id={id}");
        }
    }
}
