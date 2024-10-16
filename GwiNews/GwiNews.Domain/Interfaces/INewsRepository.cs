using GwiNews.Domain.Entities;

namespace GwiNews.Domain.Interfaces
{
    public interface INewsRepository
    {
        Task<IEnumerable<News>>? GetNewsAsync();
        Task<News>? GetByIdAsync(Guid? id);
        Task<News>? CreateAsync(News? news);
        Task<News>? UpdateAsync(News? news);
        Task<News>? RemoveAsync(News? news);
        Task<IEnumerable<News>>? GetFilteredByTitleAsync(string? title);
        Task<IEnumerable<News>>? GetFilteredByCatgoryAsync(NewsCategory? category);
        Task<IEnumerable<News>>? GetFilteredBySubcategoryAsync(NewsSubcategory? subcategory);
    }
}
