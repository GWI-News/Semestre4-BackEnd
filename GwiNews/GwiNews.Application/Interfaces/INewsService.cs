using GwiNews.Application.DTOs;
using GwiNews.Domain.Entities;

namespace GwiNews.Application.Interfaces
{
    public interface INewsService
    {
        Task<IEnumerable<NewsDTO>>? GetNewsAsync();
        Task<NewsDTO>? GetNewsByIdAsync(Guid? id);
        Task AddNewsAsync(NewsDTO? newsDto);
        Task UpdateNewsAsync(NewsDTO? newsDto);
        Task RemoveNewsAsync(Guid? id);
        Task<IEnumerable<NewsDTO>>? GetFilteredNewsByTitleAsync(string? title);
        Task<IEnumerable<NewsDTO>>? GetFilteredNewsByCategoryAsync(NewsCategory? category);
        Task<IEnumerable<NewsDTO>>? GetFilteredNewsBySubcategoryAsync(NewsSubcategory? subcategory);
    }
}
