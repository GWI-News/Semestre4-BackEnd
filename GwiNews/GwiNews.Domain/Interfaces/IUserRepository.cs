using GwiNews.Domain.Entities;

namespace GwiNews.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>>? GetUsersAsync();
        Task<User>? GetByIdAsync(Guid? id);
        Task<User>? CreateAsync(User? user);
        Task<User>? UpdateAsync(User? user);
        Task<User>? RemoveAsync(User? user);
        Task<IEnumerable<User>>? GetFilteredAsync(string name, UserRole? role);
        Task<bool>? GetStatusAsync(Guid? userId);
        Task UpdateStatusAsync(Guid? userId, bool newStatus);
    }
}
