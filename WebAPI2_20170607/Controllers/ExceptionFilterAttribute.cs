using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net;
using System.Net.Http;

namespace WebAPI2_20170607.Controllers
{
    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //if (actionExecutedContext.Exception is HttpException)
            string msg = "Exception by WebApiExceptionFilterAttribute:" + actionExecutedContext.Exception.GetBaseException().Message;
            actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, msg);
        }
       
    }
}