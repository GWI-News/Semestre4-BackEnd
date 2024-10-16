using GwiNews.Domain.Entities;

namespace GwiNews.Domain.Interfaces
{
    public interface IUserWithNewsRepository
    {
        Task<IEnumerable<UserWithNews>>? GetUsersAsync();
        Task<UserWithNews>? GetByIdAsync(Guid? id);
        Task<UserWithNews>? CreateAsync(UserWithNews? userWithNews);
        Task<UserWithNews>? UpdateAsync(UserWithNews? userWithNews);
        Task<UserWithNews>? RemoveAsync(UserWithNews? userWithNews);
        Task<IEnumerable<UserWithNews>>? GetFilteredAsync(string? completeName);
        Task<bool>? GetStatusAsync(Guid? userId);
        Task UpdateStatusAsync(Guid? userId, bool? newStatus);
    }
}
