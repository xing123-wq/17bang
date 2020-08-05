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
        public ActionResult Index(int? id)
        {
            return View(service.GetMessage(id.Value));
        }
        [HttpPost]
        public ActionResult Index(ChatItemModel model)
        {
            int id = service.Save(model);
            return Redirect($"/ChatRoom/index?id={id}");
        }
        [HttpGet]
        public ActionResult AjaxPage()
        {
            ChatRoomModel model = new ChatRoomModel();
            model.CurrentUserId = service.CurrentUserId;
            model.ChatRooms = service.GetMessages();
            return View(model);
        }
    }
}
