using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace GwiNews.API.Middleware
{
    public class NewsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<NewsMiddleware> _logger;

        public NewsMiddleware(RequestDelegate next, ILogger<NewsMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                // Log de entrada da requisição para rotas relacionadas a "api/news"
                if (context.Request.Path.StartsWithSegments("/api/news"))
                {
                    _logger.LogInformation($"Processing request: {context.Request.Method} {context.Request.Path}");
                }

                await _next(context);

                // Log de saída bem-sucedida para rotas relacionadas a "api/news"
                if (context.Request.Path.StartsWithSegments("/api/news"))
                {
                    _logger.LogInformation($"Response Status Code: {context.Response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error processing request: {context.Request.Method} {context.Request.Path}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(new { error = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
