using DbConnectivity;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using System.Linq.Expressions;
using System.Net;

namespace Contoller.Middleware
{
    public class GlobalErrorHandler
    {
        private readonly RequestDelegate _next;
        private readonly Loggingfactory _loggingFactory;
        public GlobalErrorHandler(RequestDelegate next, Loggingfactory loggingFactory   )
        {
            _next = next;
            _loggingFactory = loggingFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }

           catch(Exception ex)
        {
                var response = context.Response;
                response.ContentType = "application/json";
                switch (ex)
                {
                    case ApplicationException e:
                        {
                            response.StatusCode = (int)HttpStatusCode.BadRequest;
                            break;

                        }

                    case KeyNotFoundException e:

                        {
                            response.StatusCode = (int)HttpStatusCode.NotFound;
                            break;
                        }

                    deafult:
                        {
                            response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            break;
                        }

                }

                Log.Information("code for to catch exception from all over the project");
                Log.Error(ex, "An error occurred: {Message}", ex.Message);
                Log.Error(ex, "Stack Trace: {StackTrace}", ex.StackTrace);
                Log.Error(ex, "Inner Exception: {InnerException}", ex.InnerException?.Message);
                await _loggingFactory.projectlevelErrorlog(response.StatusCode, ex.Message, ex.StackTrace, ex.InnerException?.Message);
                await _loggingFactory.projectlevellog("krishna", "Error", $"An error occurred: {ex.Message}");

                var friendlyresponse = new ProblemDetails
                {
                    Type = "API Exception",
                    Status = (short)HttpStatusCode.InternalServerError,
                    Title = "Internal server error occured in the api"
                };

              var result=  JsonConvert.SerializeObject(friendlyresponse);

                await response.WriteAsync(result);



            }
        }
    }
}
