namespace GwiNews.API.Middleware
{
    public static class UserWithNewsMiddlewareExtensions
    {
        public static IApplicationBuilder UseUserWithNewsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserWithNewsMiddleware>();
        }
    }
}
