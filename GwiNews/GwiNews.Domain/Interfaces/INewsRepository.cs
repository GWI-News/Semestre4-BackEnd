using GwiNews.Domain.Entities;

namespace GwiNews.Domain.Interfaces
{
    public interface INewsRepository
    {
        Task<IEnumerable<News>> GetAllNews();
        Task<News> GetNewsById(Guid id);
        Task<IEnumerable<News>> GetNewsByCategory(Guid categoryId);
        Task<IEnumerable<News>> GetNewsBySubcategory(Guid subcategoryId);
        Task<IEnumerable<News>> GetNewsByStatus(NewsStatus status);
        Task<IEnumerable<News>> GetNewsByPublicationDate(DateTime publicationDate);
        Task<IEnumerable<News>> GetNewsByTitle(string title);
        Task<IEnumerable<News>> GetNewsBySubtitle(string subtitle);
        Task<IEnumerable<News>> GetNewsByBody(string body);
        Task<IEnumerable<News>> GetNewsByImageUrl(string imageUrl);
        Task<IEnumerable<News>> GetNewsByAuthor(Guid authorId);
        Task<IEnumerable<News>> GetNewsByEditor(Guid editorId);
        Task<IEnumerable<News>> GetNewsByFavoritedByUser(Guid userId);
        Task AddNews(News news);
        Task UpdateNews(News news);
        Task DeleteNews(Guid id);
    }
}
