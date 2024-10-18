using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GwiNews.Infra.Data.Repositories
{
    public class NewsSubcategoryRepository : INewsSubcategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public NewsSubcategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NewsSubcategory>>? GetSubcategoriesAsync()
        {
            return await _context.NewsSubcategories.ToListAsync();
        }

        public async Task<NewsSubcategory>? GetByIdAsync(Guid? id)
        {
            return await _context.NewsSubcategories.FindAsync(id);
        }

        public async Task<NewsSubcategory>? CreateAsync(NewsSubcategory? subcategory)
        {
            if (subcategory == null)
                return null;

            await _context.NewsSubcategories.AddAsync(subcategory);
            await _context.SaveChangesAsync();
            return subcategory;
        }

        public async Task<NewsSubcategory>? UpdateAsync(NewsSubcategory? subcategory)
        {
            if (subcategory == null || subcategory.Id == null)
                return null;

            _context.NewsSubcategories.Update(subcategory);
            await _context.SaveChangesAsync();
            return subcategory;
        }

        public async Task<NewsSubcategory>? RemoveAsync(NewsSubcategory? subcategory)
        {
            if (subcategory == null || subcategory.Id == null)
                return null;

            var existingSubcategory = await GetByIdAsync(subcategory.Id);
            if (existingSubcategory == null)
                return null;

            _context.NewsSubcategories.Remove(existingSubcategory);
            await _context.SaveChangesAsync();
            return existingSubcategory;
        }

        public async Task<IEnumerable<NewsSubcategory>>? GetFilteredAsync(string? name)
        {
            var query = _context.NewsSubcategories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(sc => sc.Name != null && sc.Name.Contains(name));
            }

            return await query.ToListAsync();
        }
    }
}
