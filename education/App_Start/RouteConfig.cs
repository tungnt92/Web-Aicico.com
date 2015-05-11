using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace education
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            "About", // chỉ là tên của Route dùng để phân biệt Route này vơi Route kia thôi, bạn muốn đặt sao cũng được
            "About", // Link sẽ hiển thị trên address bar, tương tự như 'san-pham/12/ten-san-pham '
            defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
