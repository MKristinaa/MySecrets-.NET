using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace MySecrets.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            try
            {
                await next(context);
            }
            catch (Exception ex) 
            {
                logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ProblemDetails details = new() { 
                    Status=(int)HttpStatusCode.InternalServerError,
                    Type="Server error",
                    Title="Server error",
                    Detail="Neka se greska dogodila"
                };

                string json = JsonSerializer.Serialize(details);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
