using Gnc2.Admin.App_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gnc2.Admin.Filters
{
    public class AuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.IsChildAction)
            {

                if (!SessionManager.GetInstance().IsLogin)
                    new RedirectResult("~/Login").ExecuteResult(filterContext);
                /*
            else
            {
                string currentPath = System.Web.HttpContext.Current.Request.Url.PathAndQuery;
                bool hasAccess = false;
                foreach (PanelMenuModel model in SessionManager.GetInstance().Permissions.ToList())
                {
                    if (model.AdminPath == currentPath)
                    {
                        hasAccess = true;
                        break;
                    }
                }
                if (!hasAccess)
                {
                    new RedirectResult("~/Default").ExecuteResult(filterContext);
                }
            }
                 */
            }
        }
    }
}