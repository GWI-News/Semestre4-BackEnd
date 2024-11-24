using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GwiNews.Infra.Data.Repositories
{
    public class UserWithNewsRepository : UserRepository, IUserWithNewsRepository
    {
        private readonly ApplicationDbContext _context;

        public UserWithNewsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<News?>>? GetOwnNewsAsync(Guid? userWithNewsId)
        {
            var userWithNews = await _context.Users
                .Include(u => (u as UserWithNews).News)
                .FirstOrDefaultAsync(u => u.Id == userWithNewsId && u is UserWithNews);

            return userWithNews != null ? ((UserWithNews)userWithNews).News : null;
        }

        public async Task AddOwnNewsAsync(Guid? userWithNewsId, News? news)
        {
            var userWithNews = await _context.Users
                .Include(u => (u as UserWithNews).News)
                .FirstOrDefaultAsync(u => u.Id == userWithNewsId && u is UserWithNews);

            if (userWithNews != null && news != null)
            {
                ((UserWithNews)userWithNews).News?.Add(news);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveOwnNewsAsync(Guid? userWithNewsId, News? news)
        {
            var userWithNews = await _context.Users
                .Include(u => (u as UserWithNews).News)
                .FirstOrDefaultAsync(u => u.Id == userWithNewsId && u is UserWithNews);

            if (userWithNews != null && news != null)
            {
                ((UserWithNews)userWithNews).News?.Remove(news);
                await _context.SaveChangesAsync();
            }
        }
    }
}
