using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAPI2_20170607.Controllers;

namespace WebAPI2_20170607
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 設定和服務

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // 透過動作過濾器
            config.Filters.Add(new ValidateModelAttribute());
            // 新增例外過濾器
            config.Filters.Add(new WebApiExceptionFilterAttribute());
        }
    }
}
