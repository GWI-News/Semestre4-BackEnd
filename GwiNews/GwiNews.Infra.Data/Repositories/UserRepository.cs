using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GwiNews.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>>? GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User>? GetByIdAsync(Guid? id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User>? CreateAsync(User? user)
        {
            if (user == null)
                return null;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User>? UpdateAsync(User? user)
        {
            if (user == null || user.Id == null)
                return null;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User>? RemoveAsync(User? user)
        {
            if (user == null || user.Id == null)
                return null;

            var existingUser = await GetByIdAsync(user.Id);
            if (existingUser == null)
                return null;

            _context.Users.Remove(existingUser);
            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<IEnumerable<User>>? GetFilteredAsync(string name, UserRole? role)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(u => u.CompleteName != null && u.CompleteName.Contains(name));
            }

            if (role != null)
            {
                query = query.Where(u => u.Role == role);
            }

            return await query.ToListAsync();
        }

        public async Task<bool>? GetStatusAsync(Guid? userId)
        {
            var user = await GetByIdAsync(userId);
            return user?.Status ?? false;
        }

        public async Task UpdateStatusAsync(Guid? userId, bool? newStatus)
        {
            var user = await GetByIdAsync(userId);
            if (user != null)
            {
                user.ActiveUser(newStatus);
                await UpdateAsync(user);
            }
        }
    }
}
