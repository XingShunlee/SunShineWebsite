using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ehaiker;
using System.Runtime.Remoting.Messaging;
using ehaiker.Auth;

namespace ehaiker
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //过滤
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //启用路由特性MVC5
           // routes.MapMvcAttributeRoutes();
            //构建数据库对象
            EhaikerContext db = CallContext.GetData("DBEHaiker") as EhaikerContext;
            if (db == null)
            {
                db = new EhaikerContext();

                CallContext.SetData("DBEHaiker", db);
            }
            //默认路由
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "EHaiker", action = "Index", id = UrlParameter.Optional }
            );
        // InstallController.InstallSQL();
        }
    }
}