using Microsoft.AspNetCore.Builder;

namespace GwiNews.API.Middleware
{
    public static class NewsCategoryMiddlewareExtensions
    {
        public static IApplicationBuilder UseNewsCategoryMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<NewsCategoryMiddleware>();
        }
    }
}
