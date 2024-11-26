using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace GwiNews.API.Middleware
{
    public class NewsCategoryMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<NewsCategoryMiddleware> _logger;

        public NewsCategoryMiddleware(RequestDelegate next, ILogger<NewsCategoryMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            // Customize response messages based on exception types
            string errorMessage;
            if (exception is KeyNotFoundException)
            {
                code = HttpStatusCode.NotFound;
                errorMessage = "Category not found.";
            }
            else if (exception is ArgumentException)
            {
                code = HttpStatusCode.BadRequest;
                errorMessage = "Invalid category data provided.";
            }
            else
            {
                errorMessage = "An unexpected error occurred.";
            }

            var result = JsonSerializer.Serialize(new { error = errorMessage });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            await context.Response.WriteAsync(result);
        }
    }
}
