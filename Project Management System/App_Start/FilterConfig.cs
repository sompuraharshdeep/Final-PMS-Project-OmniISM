﻿using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project_Management_System
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }

    public class AdminAuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["adminId"] == null)
            {
                FormsAuthentication.SignOut();
                filterContext.Result = new
                    RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary {
                        {"action","Login"},
                        {"controller","SignIn"},
                        {"returnUrl",filterContext.HttpContext.Request.RawUrl}
                    });
                return;
            }
        }

    }
}
