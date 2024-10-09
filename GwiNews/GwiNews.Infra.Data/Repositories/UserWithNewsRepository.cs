using GwiNews.Domain.Entities;
using GwiNews.Infra.Data.Interfaces;
using GwiNews.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GwiNews.Infra.Data.Repositories
{
    public class UserWithNewsRepository : IUserWithNewsRepository
    {
        private readonly ApplicationDbContext _context;

        public UserWithNewsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserWithNews> GetByIdAsync(Guid id)
        {
            return await _context.UsersWithNews.FindAsync(id);
        }

        public async Task<IEnumerable<UserWithNews>> GetAllAsync()
        {
            return await _context.UsersWithNews.ToListAsync();
        }

        public async Task AddAsync(UserWithNews userWithNews)
        {
            await _context.UsersWithNews.AddAsync(userWithNews);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserWithNews userWithNews)
        {
            _context.UsersWithNews.Update(userWithNews);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var userWithNews = await GetByIdAsync(id);
            if (userWithNews != null)
            {
                _context.UsersWithNews.Remove(userWithNews);
                await _context.SaveChangesAsync();
            }
        }
    }
}
