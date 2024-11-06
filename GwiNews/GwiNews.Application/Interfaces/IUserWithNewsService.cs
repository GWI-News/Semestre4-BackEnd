using GwiNews.Application.DTOs;

namespace GwiNews.Application.Interfaces
{
    public interface IUserWithNewsService : IUserService
    {
        Task<IEnumerable<NewsDTO>>? GetOwnNewsAsync(Guid? userWithNewsId);
        Task AddOwnNewsAsync(Guid? userWithNewsId, NewsDTO? newsDto);
        Task RemoveOwnNewsAsync(Guid? userWithNewsId, NewsDTO? newsDto);
    }
}
