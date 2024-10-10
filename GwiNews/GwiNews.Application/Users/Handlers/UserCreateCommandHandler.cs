using GwiNews.Application.Users.Commands;
using GwiNews.Domain.Entities;
using GwiNews.Infra.Data.Repositories;
using MediatR;

namespace GwiNews.Application.Users.Handlers
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, User>
    {
        private readonly UserRepository _userRepository;

        public UserCreateCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Role, request.CompleteName, request.Email, request.Password, request.Status);

            if (user == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                return await _userRepository.CreateUserAsync(user);
            }
        }
    }
}
