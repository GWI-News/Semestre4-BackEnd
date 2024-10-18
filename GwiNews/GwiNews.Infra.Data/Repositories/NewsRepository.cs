using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GwiNews.Infra.Data.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly ApplicationDbContext _context;

        public NewsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<News>>? GetNewsAsync()
        {
            return await _context.News.ToListAsync();
        }

        public async Task<News>? GetByIdAsync(Guid? id)
        {
            return await _context.News.FindAsync(id);
        }

        public async Task<News>? CreateAsync(News? news)
        {
            if (news == null)
                return null;

            await _context.News.AddAsync(news);
            await _context.SaveChangesAsync();
            return news;
        }

        public async Task<News>? UpdateAsync(News? news)
        {
            if (news == null || news.Id == null)
                return null;

            _context.News.Update(news);
            await _context.SaveChangesAsync();
            return news;
        }

        public async Task<News>? RemoveAsync(News? news)
        {
            if (news == null || news.Id == null)
                return null;

            var existingNews = await GetByIdAsync(news.Id);
            if (existingNews == null)
                return null;

            _context.News.Remove(existingNews);
            await _context.SaveChangesAsync();
            return existingNews;
        }

        public async Task<IEnumerable<News>>? GetFilteredByTitleAsync(string? title)
        {
            var query = _context.News.AsQueryable();

            if (!string.IsNullOrWhiteSpace(title))
            {
                query = query.Where(n => n.Title != null && n.Title.Contains(title));
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<News>>? GetFilteredByCatgoryAsync(NewsCategory? category)
        {
            var query = _context.News.AsQueryable();

            if (category != null)
            {
                query = query.Where(n => n.NewsCategory == category);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<News>>? GetFilteredBySubcategoryAsync(NewsSubcategory? subcategory)
        {
            var query = _context.News.AsQueryable();

            if (subcategory != null)
            {
                query = query.Where(n => n.NewsSubcategories.Any(sc => sc == subcategory));
            }

            return await query.ToListAsync();
        }
    }
}
