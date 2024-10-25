using GwiNews.Application.DTOs;
using GwiNews.Domain.Entities;

namespace GwiNews.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>>? GetUsersAsync();
        Task<UserDTO>? GetUserByIdAsync(Guid? id);
        Task AddUserAsync(UserDTO? userDto);
        Task UpdateUserAsync(UserDTO? userDto);
        Task RemoveUserAsync(Guid? id);
        Task<IEnumerable<UserDTO>>? GetFilteredUsersAsync(string? name, UserRole? role);
        Task<bool>? GetUserStatusAsync(Guid? userId);
        Task UpdateUserStatusAsync(Guid? userId, bool? newStatus);
    }
}
