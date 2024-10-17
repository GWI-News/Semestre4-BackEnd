using GwiNews.Domain.Entities;

namespace GwiNews.Domain.Interfaces
{
    public interface IUserWithNewsRepository : IUserRepository
    {
        Task<IEnumerable<News>>? GetOwnNewsAsync(Guid? userWithNewsId);
        Task AddOwnNewsAsync(Guid? userWithNewsId, News? news);
        Task RemoveOwnNewsAsync(Guid? userWithNewsId, News? news);
    }
}
