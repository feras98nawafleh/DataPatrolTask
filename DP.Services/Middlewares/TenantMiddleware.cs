using Microsoft.AspNetCore.Http;

namespace DP.Services.Middlewares
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var tenantId = context.Request.Headers["X-Tenant-Id"].FirstOrDefault();

            if (string.IsNullOrEmpty(tenantId))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Tenant ID is required.");
                return;
            }

            context.Items["TenantId"] = tenantId;

            await _next(context);
        }
    }
}
