using GwiNews.Application.DTOs;
using GwiNews.Domain.Entities;

namespace GwiNews.Application.Interfaces
{
    public interface INewsSubcategoryService
    {
        Task<IEnumerable<NewsSubcategoryDTO>> GetSubcategoriesAsync();
        Task<NewsSubcategoryDTO> GetByIdAsync(Guid id);
        Task<NewsSubcategoryDTO> CreateAsync(NewsSubcategory subcategory);
        Task<NewsSubcategoryDTO> UpdateAsync(NewsSubcategory subcategory);
        Task<NewsSubcategoryDTO> RemoveAsync(NewsSubcategory subcategory);
        Task<IEnumerable<NewsSubcategoryDTO>> GetFilteredAsync(string name);

    }
}
