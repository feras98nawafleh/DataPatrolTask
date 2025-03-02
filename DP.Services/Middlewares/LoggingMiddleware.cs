using Microsoft.AspNetCore.Http;
using Serilog;

namespace DP.Services.Middlewares
{
    public class LoggingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Log.Information($"Incoming Request: {context.Request.Method} {context.Request.Path}");
            await next(context);
            Log.Information($"Outgoing Response: {context.Response.StatusCode}");
        }
    }
}
