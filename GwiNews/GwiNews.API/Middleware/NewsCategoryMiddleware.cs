//using Interfaces;
//using System.Net;
//using System.Text.Json;

//namespace GwiNews.API.Middleware
//{
//    public class NewsCategoryMiddleware
//    {
//        private readonly RequestDelegate _next;
//        private readonly ILogger<NewsCategoryMiddleware> _logger;
//        private readonly INewsCategoryRepository _newsCategoryRepository; 

//        public NewsCategoryMiddleware(RequestDelegate next,
//                                      ILogger<NewsCategoryMiddleware> logger,
//                                      INewsCategoryRepository newsCategoryRepository) 
//        {
//            _next = next;
//            _logger = logger;
//            _newsCategoryRepository = newsCategoryRepository;
//        }

//        public async Task Invoke(HttpContext context)
//        {
//            try
//            {
//                await _next(context);

//                var categoryId = context.Request.Query["categoryId"];
//                if (Guid.TryParse(categoryId, out var id))
//                {
//                    _logger.LogInformation("Handling NewsCategory-specific functionality...");

//                    var category = await _newsCategoryRepository.GetNewsCategoryById(id); 
//                    if (category != null && string.IsNullOrEmpty(category.Name))
//                    {
//                        throw new InvalidOperationException("Category name cannot be empty.");
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "An unhandled exception occurred in NewsCategory processing.");

//                await HandleExceptionAsync(context, ex);
//            }
//        }

//        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
//        {
//            var statusCode = HttpStatusCode.InternalServerError;
//            var response = JsonSerializer.Serialize(new { message = exception.Message });

//            context.Response.ContentType = "application/json";
//            context.Response.StatusCode = (int)statusCode;

//            return context.Response.WriteAsync(response);
//        }
//    }
//}
