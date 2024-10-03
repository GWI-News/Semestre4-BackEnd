using GwiNews.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwiNews.Infra.Data.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly ApplicationDbContext _context;

        public NewsCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<News>> GetAllNews()
        {
            return await _context.News.ToListAsync();
        }

        public async Task<News> GetNewsById(Guid id)
        {
            return await _context.News.FindAsync(id);
        }

        public async Task<IEnumerable<News>> GetNewsByStatus(NewsStatus status)
        {
            return await _context.News
                .Where(n => n.Status == status)
                .ToListAsync();
        }

        public async Task AddNews(News news)
        {
            _context.News.Add(news);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNews(News news)
        {
            _context.News.Update(news);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNews(Guid id)
        {
            var news = await _context.News.FindAsync(id);
            if (news != null)
            {
                _context.News.Remove(news);
                await _context.SaveChangesAsync();
            }
        }

        /*public async Task<IEnumerable<News>> GetNewsWithSubcategories()
        {
            return await _context.News
                .Include(n => n.NewsSubcategories)
                .ToListAsync();
        }
        */
    }
}
