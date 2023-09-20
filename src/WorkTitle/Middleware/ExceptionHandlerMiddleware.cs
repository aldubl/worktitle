using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace WorkTitle.Api.Middleware
{
    public sealed class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (KeyNotFoundException ex)
            {
                await HandleNotFoundExceptionMessageAsync(context, ex).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await HandleExceptionMessageAsync(context, ex).ConfigureAwait(false);
            }
        }

        private static Task HandleNotFoundExceptionMessageAsync(HttpContext context, KeyNotFoundException exception)
        {
            return HandleException(context, exception, HttpStatusCode.NotFound);            
        }

        private static Task HandleExceptionMessageAsync(HttpContext context, Exception exception)
        {
            return HandleException(context, exception, HttpStatusCode.InternalServerError);
          
        }

        private static Task HandleException(HttpContext context, Exception exception, HttpStatusCode statusCodeInput)
        {
            context.Response.ContentType = "application/json";
            int statusCode = (int)statusCodeInput;
            var result = JsonConvert.SerializeObject(new
            {
                StatusCode = statusCode,
                ErrorMessage = exception.Message + (exception.InnerException is not null ?
                    $" Inner exception: {exception.InnerException.Message}" : "")
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(result);
        }
    }
}
