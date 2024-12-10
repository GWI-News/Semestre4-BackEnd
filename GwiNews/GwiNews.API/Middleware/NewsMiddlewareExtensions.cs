using Microsoft.AspNetCore.Builder;

namespace GwiNews.API.Middleware
{
    public static class NewsMiddlewareExtensions
    {
        public static IApplicationBuilder UseNewsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<NewsMiddleware>();
        }
    }
}
