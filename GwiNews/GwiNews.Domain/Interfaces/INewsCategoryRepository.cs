using GwiNews.Domain.Entities;

namespace GwiNews.Domain.Interfaces
{
    public interface INewsCategoryRepository
    {
        Task<IEnumerable<NewsCategory>>? GetCategoriesAsync();
        Task<NewsCategory>? GetByIdAsync(Guid? id);
        Task<NewsCategory>? CreateAsync(NewsCategory? category);
        Task<NewsCategory>? UpdateAsync(NewsCategory? category);
        Task<NewsCategory>? RemoveAsync(NewsCategory? category);
        Task<IEnumerable<NewsCategory>>? GetFilteredAsync(string? name);
    }
}
