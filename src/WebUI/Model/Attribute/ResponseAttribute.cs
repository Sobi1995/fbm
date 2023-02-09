using System.Drawing;
using System.Net;
using System.Reflection;
using Application.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebUI.Model.Attribute;
public class ResponseAttribute : ActionFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (context.Result is OkObjectResult okObjectResult)
        {
            var t = okObjectResult.Value?.GetType();
            PropertyInfo? p = t?.GetProperty(nameof(HttpStatusCode));
            var statusCode = (HttpStatusCode?)p?.GetValue(okObjectResult.Value, null);
            context.Result = new JsonResult(okObjectResult.Value) { StatusCode = (int)statusCode };
        }
  

        base.OnResultExecuting(context);
    }
 
}

