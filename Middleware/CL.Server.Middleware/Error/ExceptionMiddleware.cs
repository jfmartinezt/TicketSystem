
using CL.Server.Middleware.Error;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Servidor.Web.Middleware
{
  public class ExceptionMiddleware
  {
    private static JsonSerializerSettings serializerSettings =  new JsonSerializerSettings 
    { 
        ContractResolver = new CamelCasePropertyNamesContractResolver()
    };

    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
      try
      {
        await _next(httpContext);
      }
      catch (Exception ex)
      {
        await HandleExceptionAsync(httpContext, ex);
      }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

      Log.Information(exception.Message);
      Log.Information(exception.StackTrace);

      if (exception is CustomException)
      {
        CustomException ex = (CustomException)exception;
        return context.Response.WriteAsync(JsonConvert.SerializeObject(new CustomResult()
        {
          Category = "ERROR",
          Message = ex.CustomMessage,
          TimeStamp = DateTime.Now
        }, serializerSettings));
      }
      
      return context.Response.WriteAsync(JsonConvert.SerializeObject(new CustomResult()
      {
        Category = "ERROR",
        Message = "An unhandled error ocurred.",
        TimeStamp = DateTime.Now
      }, serializerSettings));
    }
  }
}
