using GwiNews.Domain.Entities;

namespace GwiNews.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdUserAsync(Guid? id);
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<User> DeleteUserAsync(Guid? id);
        Task<User> GetByEmailUserAsync(string email);
        Task<User> StatusChangeUserAsync(Guid id);
    }
}
