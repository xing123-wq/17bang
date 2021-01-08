using _17bangMvc.Filters;
using _17bangMvc.Helper;
using ProdService;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17bangMvc.Controllers
{
    [ContextPerRequest]
    public class BaseController : Controller
    {
        private IBaseService _service;
        public BaseController()
        {
            _service = new BaseService();
        }
    }
}