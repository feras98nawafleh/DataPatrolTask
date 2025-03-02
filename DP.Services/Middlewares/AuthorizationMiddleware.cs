using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace DP.Services.Middlewares
{
    public class AuthorizationMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (!context.User.Identity.IsAuthenticated && context?.GetEndpoint()?.Metadata.GetMetadata<AllowAnonymousAttribute>() == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized: Please log in.");
                return;
            }

            await next(context);
        }
    }
}
