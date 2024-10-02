using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwiNews.Domain.Interfaces
{
    public interface INewsRepository
    {
        Task<IEnumerable<News>> GetAllNews();
        Task<News> GetNewsById(Guid id);
        Task<IEnumerable<News>> GetNewsByTitle(string title);
        Task<IEnumerable<News>> GetNewsByCategory(string category);
        Task<IEnumerable<News>> GetNewsBySubcategory(string subcategory);
        Task<IEnumerable<News>> GetNewsByStatus(NewsStatus status);
        Task<IEnumerable<News>> GetNewsByPublicationDate(DateTime publicationDate);
        Task<IEnumerable<News>> GetNewsByAuthor(Guid authorId);
        Task<IEnumerable<News>> GetNewsByEditor(Guid editorId);
        Task<IEnumerable<News>> GetNewsByFavoritedByUser(Guid userId);
        Task AddNews(News news);
        Task UpdateNews(News news);
        Task DeleteNews(Guid id);

    }
}
