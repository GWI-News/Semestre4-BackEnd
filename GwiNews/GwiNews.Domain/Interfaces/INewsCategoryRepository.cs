using GwiNews.Domain.Entities;

namespace Interfaces
{
    public interface INewsCategoryRepository
    {
        Task<NewsCategory> GetNewsCategoryById(Guid id);
        Task<IEnumerable<NewsCategory>> GetAllNewsCategories();
        Task AddNewsCategory(NewsCategory newsCategory);
        Task UpdateNewsCategory(NewsCategory newsCategory);
        Task DeleteNewsCategory(Guid id);
        //Task<IEnumerable<NewsCategory>> GetNewsCategoriesWithSubcategories();
    }
}
