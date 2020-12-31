using ProdService;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17bangMvc.Filters
{
    public class ContextPerRequest : ActionFilterAttribute
    {
        private IBaseService _Service;
        public ContextPerRequest()
        {
            _Service = new BaseService();
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (!filterContext.IsChildAction)
            {
                if (filterContext.Exception == null)
                {
                    _Service.Commit();
                }
                else
                {
                    _Service.Rollback();
                }
                _Service.ClearContext();
            }
            base.OnResultExecuted(filterContext);
        }
    }
}