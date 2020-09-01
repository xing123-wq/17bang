using ProdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _17bangMvc.Controllers
{
    public class Dependency<T> : BaseController where T : BaseService
    {
        protected BaseService service;
        public Dependency(BaseService service)
        {
            this.service = service;
        }
    }
}