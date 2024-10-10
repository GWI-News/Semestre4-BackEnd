using GwiNews.Domain.Entities;
using GwiNews.Infra.Data.Context;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class NewsCategoryRepository : INewsCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public NewsCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<NewsCategory> GetNewsCategoryById(Guid id)
        {
            return await _context.NewsCategories.FindAsync(id);
        }
        
        public async Task<IEnumerable<News>> GetNewsByCategory(Guid categoryId)
        {
            return await _context.News.Where(n => n.NewsCategoryId == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<NewsCategory>> GetAllNewsCategories()
        {
            return await _context.NewsCategories.ToListAsync();
        }

        public async Task<NewsCategory> AddNewsCategory(NewsCategory newsCategory)
        {
            await _context.NewsCategories.AddAsync(newsCategory);
            await _context.SaveChangesAsync();
            return newsCategory;
        }

        public async Task<NewsCategory> UpdateNewsCategory(NewsCategory newsCategory)
        {
            _context.NewsCategories.Update(newsCategory);
            await _context.SaveChangesAsync();
            return newsCategory;
        }

        public async Task<NewsCategory> DeleteNewsCategory(Guid id)
        {
            var newsCategory = await _context.NewsCategories.FindAsync(id);
            if (newsCategory != null) return null;
            
            _context.NewsCategories.Remove(newsCategory);
            await _context.SaveChangesAsync();
            return newsCategory;
        }

        /*public async Task<IEnumerable<NewsCategory>> GetNewsCategoriesWithSubcategories()
        {
            return await _context.NewsCategories
                .Include(nc => nc.NewsSubcategories)
                .ToListAsync();
        }*/
    }
}
