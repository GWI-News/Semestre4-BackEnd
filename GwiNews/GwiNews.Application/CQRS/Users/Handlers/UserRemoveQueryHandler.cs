using MediatR;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Application.CQRS.Users.Commands;

namespace GwiNews.Application.CQRS.Users.Handlers
{
    public class UserRemoveCommandHandler : IRequestHandler<UserRemoveCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public UserRemoveCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(UserRemoveCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
                return null;

            var removedUser = await _userRepository.RemoveAsync(user);

            return removedUser;
        }
    }
}
