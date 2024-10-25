using AutoMapper;
using GwiNews.Application.DTOs;
using GwiNews.Application.Interfaces;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;

namespace GwiNews.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task AddUserAsync(UserDTO? userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            await _userRepository.CreateAsync(userEntity);
        }

        public async Task<IEnumerable<UserDTO>>? GetUsersAsync()
        {
            var usersEntity = await _userRepository.GetUsersAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(usersEntity);
        }

        public async Task<UserDTO>? GetUserByIdAsync(Guid? id)
        {
            var userEntity = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(userEntity);
        }

        public async Task RemoveUserAsync(Guid? id)
        {
            var userEntity = await _userRepository.GetByIdAsync(id);
            if (userEntity != null)
            {
                await _userRepository.RemoveAsync(userEntity);
            }
        }

        public async Task UpdateUserAsync(UserDTO? userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            await _userRepository.UpdateAsync(userEntity);
        }

        public async Task<IEnumerable<UserDTO>>? GetFilteredUsersAsync(string? name, UserRole? role)
        {
            var users = await _userRepository.GetFilteredAsync(name, role);
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<bool>? GetUserStatusAsync(Guid? userId)
        {
            return await _userRepository.GetStatusAsync(userId);
        }

        public async Task UpdateUserStatusAsync(Guid? userId, bool? newStatus)
        {
            await _userRepository.UpdateStatusAsync(userId, newStatus);
        }
    }
}
