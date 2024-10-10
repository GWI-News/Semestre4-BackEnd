using GwiNews.Application.Users.Commands;
using GwiNews.Domain.Entities;
using GwiNews.Infra.Data.Repositories;
using MediatR;

namespace GwiNews.Application.Users.Handlers
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, User>
    {
        private readonly UserRepository _userRepository;

        public UserUpdateCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdUserAsync(request.Id);

            if (user == null)
            {
                throw new ApplicationException($"User not found.");
            }

            return await _userRepository.UpdateUserAsync(user);
        }
    }
}
