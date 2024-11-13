using MediatR;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Application.CQRS.UsersCQRS.Commands;

namespace GwiNews.Application.CQRS.UsersCQRS.Handlers
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public UserCreateCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var newUser = new User(request.Id, request.Role, request.CompleteName, request.Email, request.PasswordHash, request.Status ?? true);

            var createdUser = await _userRepository.CreateAsync(newUser);

            return createdUser;
        }
    }
}
