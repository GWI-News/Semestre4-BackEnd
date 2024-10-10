using GwiNews.Application.DTOs;

namespace GwiNews.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUsers();
        Task<UserDTO> GetUserById(Guid id);
        Task AddUser(UserDTO userDto);
        Task UpdateUser(UserDTO userDto);
        Task RemoveUser(Guid id);
        Task<UserDTO> GetUserByEmail(string email);
    }
}
