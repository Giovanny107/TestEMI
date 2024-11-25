using System.Diagnostics;

namespace TestEMI.Api.Middlewares
{
    public class LoggingDetailsMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingDetailsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Debug.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

            await _next(context);

            Debug.WriteLine($"Response: {context.Response.StatusCode}");
        }
    }
}
