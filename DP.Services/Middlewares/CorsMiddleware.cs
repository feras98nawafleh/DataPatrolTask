using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace DP.Services.Middlewares
{
    public class CorsMiddleware : IMiddleware
    {
        private readonly IConfiguration _configuration;
        public CorsMiddleware(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var allowedOrigins = _configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();
            var origin = context.Request.Headers["Origin"].ToString();

            if (string.IsNullOrEmpty(origin) && context.Request.Method == "GET")
            {
                context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
                await next(context);
                return;
            }

            if (!allowedOrigins.Contains(origin))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Forbidden: Origin not allowed.");
                return;
            }

            context.Response.Headers.Append("Access-Control-Allow-Origin", origin);
            context.Response.Headers.Append("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
            context.Response.Headers.Append("Access-Control-Allow-Headers", "Content-Type, Authorization");

            if (context.Request.Method == "OPTIONS")
            {
                context.Response.StatusCode = StatusCodes.Status204NoContent;
                return;
            }

            await next(context);
        }
    }
}
