using GwiNews.Application.DTOs;

namespace GwiNews.Application.Interfaces
{
    public interface INewsSubcategoryService
    {
        Task<IEnumerable<NewsSubcategory>> GetSubcategoriesAsync();
        Task<NewsSubcategory> GetByIdAsync(Guid id);
        Task<NewsSubcategory> CreateAsync(NewsSubcategory subcategory);
        Task<NewsSubcategory> UpdateAsync(NewsSubcategory subcategory);
        Task<NewsSubcategory> RemoveAsync(NewsSubcategory subcategory);
        Task<IEnumerable<NewsSubcategory>> GetFilteredAsync(string name);

    }
}
