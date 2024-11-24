using MediatR;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Application.CQRS.UserWithNewsCQRS.Commands;
using GwiNews.Application.CQRS.UsersCQRS.Handlers;

namespace GwiNews.Application.CQRS.UserWithNewsCQRS.Handlers
{
    public class UserWithNewsRemoveCommandHandler : UserRemoveCommandHandler, IRequestHandler<UserWithNewsRemoveCommand, UserWithNews>
    {
        private readonly IUserWithNewsRepository _userWithNewsRepository;

        public UserWithNewsRemoveCommandHandler(IUserWithNewsRepository userWithNewsRepository) : base(userWithNewsRepository)
        {
            _userWithNewsRepository = userWithNewsRepository;
        }

        public async Task<UserWithNews> Handle(UserWithNewsRemoveCommand request, CancellationToken cancellationToken)
        {
            var userWithNews = await _userWithNewsRepository.GetByIdAsync(request.Id) as UserWithNews;

            if (userWithNews == null)
                return null;

            var removedUserWithNews = await _userWithNewsRepository.RemoveAsync(userWithNews);

            UserWithNews removedUser = new UserWithNews(
                removedUserWithNews.Id,
                removedUserWithNews.Role,
                removedUserWithNews.CompleteName,
                removedUserWithNews.Email,
                removedUserWithNews.Password,
                removedUserWithNews.Status,
                null
            );

            return removedUser;
        }
    }
}
