using MediatR;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Application.CQRS.UserWithNewsCQRS.Commands;
using GwiNews.Application.UsersCQRS.Handlers;

namespace GwiNews.Application.CQRS.UserWithNewsCQRS.Handlers
{
    public class UserWithNewsUpdateCommandHandler : UserUpdateCommandHandler, IRequestHandler<UserWithNewsUpdateCommand, UserWithNews>
    {
        private readonly IUserWithNewsRepository _userWithNewsRepository;

        public UserWithNewsUpdateCommandHandler(IUserWithNewsRepository userWithNewsRepository) 
            : base(userWithNewsRepository)
        {
            _userWithNewsRepository = userWithNewsRepository;
        }

        public async Task<UserWithNews> Handle(UserWithNewsUpdateCommand request, CancellationToken cancellationToken)
        {
            var userWithNews = await _userWithNewsRepository.GetByIdAsync(request.Id) as UserWithNews;

            if (userWithNews == null)
            {
                throw new ApplicationException("User not found.");
            }

            var userWithNewsToUpdate = new UserWithNews(
                userWithNews.Id,
                request.Role ?? userWithNews.Role,
                request.CompleteName ?? userWithNews.CompleteName,
                request.Email ?? userWithNews.Email,
                request.PasswordHash ?? userWithNews.Password,
                request.Status ?? userWithNews.Status,
                userWithNews.News
            );

            var updatedUserWithNews = await _userWithNewsRepository.UpdateAsync(userWithNewsToUpdate);

            UserWithNews userReturned = new UserWithNews(
                updatedUserWithNews.Id,
                updatedUserWithNews.Role,
                updatedUserWithNews.CompleteName,
                updatedUserWithNews.Email,
                updatedUserWithNews.Password,
                updatedUserWithNews.Status,
                userWithNews.News
            );

            return userReturned;
        }
    }
}
