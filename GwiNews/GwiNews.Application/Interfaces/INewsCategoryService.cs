using GwiNews.Application.DTOs;

namespace GwiNews.Application.Interfaces
{
    public interface INewsCategoryService
    {
        Task<IEnumerable<NewsCategoryDTO>>? GetCategoriesAsync();
        Task<NewsCategoryDTO>? GetCategoryByIdAsync(Guid? id);
        Task<NewsCategoryDTO>? AddCategoryAsync(NewsCategoryDTO? categoryDto);
        Task<NewsCategoryDTO>? UpdateCategoryAsync(NewsCategoryDTO? categoryDto);
        Task<NewsCategoryDTO>? RemoveCategoryAsync(Guid? id);
        Task<IEnumerable<NewsCategoryDTO>>? GetFilteredCategoriesAsync(string? name);
    }
}
