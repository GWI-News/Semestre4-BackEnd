using GwiNews.Domain.Entities;

namespace Interfaces
{
    public interface INewsCategoryRepository
    {
        Task<NewsCategory> GetNewsCategoryById(Guid id);
        Task<IEnumerable<News>> GetNewsByCategory(Guid categoryId);
        Task<IEnumerable<NewsCategory>> GetAllNewsCategories();
        Task<NewsCategory> AddNewsCategory(NewsCategory newsCategory);
        Task<NewsCategory> UpdateNewsCategory(NewsCategory newsCategory);
        Task<NewsCategory> DeleteNewsCategory(Guid id);
        //Task<IEnumerable<NewsCategory>> GetNewsCategoriesWithSubcategories();
    }
}
