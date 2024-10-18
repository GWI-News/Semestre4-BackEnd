using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GwiNews.Infra.Data.Repositories
{
    public class NewsCategoryRepository : INewsCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public NewsCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NewsCategory>>? GetCategoriesAsync()
        {
            return await _context.NewsCategories.ToListAsync();
        }

        public async Task<NewsCategory>? GetByIdAsync(Guid? id)
        {
            return await _context.NewsCategories.FindAsync(id);
        }

        public async Task<NewsCategory>? CreateAsync(NewsCategory? category)
        {
            if (category == null)
                return null;

            await _context.NewsCategories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<NewsCategory>? UpdateAsync(NewsCategory? category)
        {
            if (category == null || category.Id == null)
                return null;

            _context.NewsCategories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<NewsCategory>? RemoveAsync(NewsCategory? category)
        {
            if (category == null || category.Id == null)
                return null;

            var existingCategory = await GetByIdAsync(category.Id);
            if (existingCategory == null)
                return null;

            _context.NewsCategories.Remove(existingCategory);
            await _context.SaveChangesAsync();
            return existingCategory;
        }

        public async Task<IEnumerable<NewsCategory>>? GetFilteredAsync(string? name)
        {
            var query = _context.NewsCategories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(c => c.Name != null && c.Name.Contains(name));
            }

            return await query.ToListAsync();
        }
    }
}
