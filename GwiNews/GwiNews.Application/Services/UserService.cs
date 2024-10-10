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

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var usersEntity = await _userRepository.GetAllUserAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(usersEntity);
        }

        public async Task<UserDTO> GetUserById(Guid? id)
        {
            var userEntity = await _userRepository.GetByIdUserAsync(id);
            return _mapper.Map<UserDTO>(userEntity);
        }

        public async Task AddUser(UserDTO userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            await _userRepository.CreateUserAsync(userEntity);
        }

        public async Task RemoveUser(Guid? id)
        {
            var userEntity = await _userRepository.GetByIdUserAsync(id);
            await _userRepository.DeleteUserAsync(userEntity.Id);
        }

        public async Task UpdateUser(UserDTO userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            await _userRepository.UpdateUserAsync(userEntity);
        }

        public async Task<UserDTO> GetUserByEmail(string email)
        {
            var userEntity = await _userRepository.GetByEmailUserAsync(email);
            return _mapper.Map<UserDTO>(userEntity);
        }
    }
}
