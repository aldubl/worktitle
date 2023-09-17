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
            context.Response.ContentType = "application/json";
            int statusCode = (int)HttpStatusCode.NotFound;
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

        private static Task HandleExceptionMessageAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            int statusCode = (int)HttpStatusCode.InternalServerError;
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
