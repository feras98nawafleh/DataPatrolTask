using DP.Core.Builders;
using Microsoft.AspNetCore.Http;
using Serilog;
using System.Net;
using System.Text.Json;

namespace DP.Services.Middlewares
{
    public class CustomException : Exception
    {
        public HttpStatusCode StatusCode;
        public CustomException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest) : base(message)
        {
            StatusCode = statusCode;
        }
    }

    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (CustomException ex)
            {
                Log.Error(ex, "A custom exception occurred.");

                var response = new ResponseEnvelopeBuilder<object>()
                    .WithError()
                    .WithData(new object { })
                    .WithMessage(ex.Message)
                    .WithStatusCode(ex.StatusCode)
                    .Build();

                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An unhandled exception occurred.");

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("Internal Server Error! Please try again later.");
            }
        }

    }
}
