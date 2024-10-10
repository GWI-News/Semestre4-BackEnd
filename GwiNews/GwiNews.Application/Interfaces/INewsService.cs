using GwiNews.Application.DTOs;


namespace GwiNews.Application.Interfaces
{
    public interface INewsService
    {
        Task<IEnumerable<NewsDTO>> GetNews();

        Task<NewsDTO> GetNewsById(Guid id);

        Task AddNews(NewsDTO newsDto);

        Task UpdateNews(NewsDTO newsDto);

        Task RemoveNews(Guid id);

        /*
        Task<IEnumerable<NewsDTO>> GetNewsByStatus(NewsStatus status);

        Task<IEnumerable<NewsDTO>> GetNewsByCategory(Guid categoryId);

        Task<IEnumerable<ReaderUserDTO>> GetFavoritedByUsers(Guid newsId); */
    }
}
