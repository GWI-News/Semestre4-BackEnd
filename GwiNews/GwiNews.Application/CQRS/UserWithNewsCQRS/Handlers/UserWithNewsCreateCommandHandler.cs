using MediatR;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Application.CQRS.UserWithNewsCQRS.Commands;
using GwiNews.Application.CQRS.UsersCQRS.Handlers;

namespace GwiNews.Application.CQRS.UserWithNewsCQRS.Handlers
{
    public class UserWithNewsCreateCommandHandler : UserCreateCommandHandler, IRequestHandler<UserWithNewsCreateCommand, UserWithNews>
    {
        private readonly IUserWithNewsRepository _userWithNewsRepository;

        public UserWithNewsCreateCommandHandler(IUserWithNewsRepository userWithNewsRepository) : base(userWithNewsRepository)
        {
            _userWithNewsRepository = userWithNewsRepository;
        }

        public async Task<UserWithNews> Handle(UserWithNewsCreateCommand request, CancellationToken cancellationToken)
        {
            var user = new User(
                request.Id,
                request.Role,
                request.CompleteName,
                request.Email,
                request.PasswordHash,
                request.Status ?? true
            );

            var ownNews = request.News;

            var createdUserWithNews = await _userWithNewsRepository.CreateAsync(user);

            foreach (var item in ownNews) {
                await _userWithNewsRepository.AddOwnNewsAsync(createdUserWithNews.Id, item);
            };

            var userWithNews = new UserWithNews(
                createdUserWithNews.Id,
                createdUserWithNews.Role,
                createdUserWithNews.CompleteName,
                createdUserWithNews.Email,
                createdUserWithNews.Password,
                createdUserWithNews.Status,
                ownNews
            );

            return userWithNews;
        }
    }
}
