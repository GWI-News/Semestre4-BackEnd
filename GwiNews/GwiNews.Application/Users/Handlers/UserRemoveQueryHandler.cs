using GwiNews.Application.Users.Commands;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using MediatR;

namespace GwiNews.Application.Users.Handlers
{
    public class UserRemoveQueryHandler : IRequestHandler<UserRemoveCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public UserRemoveQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(UserRemoveCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdUserAsync(request.Id);

            if (user == null)
            {
                throw new ApplicationException($"User not found.");
            }

            return await _userRepository.DeleteUserAsync(user.Id);
        }
    }
}
