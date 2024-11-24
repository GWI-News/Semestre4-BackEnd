using GwiNews.Application.CQRS.UserWithNewsCQRS.Queries;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace GwiNews.Application.CQRS.UserWithNewsCQRS.Handlers
{
    public class GetUserWithNewsByIdQueryHandler(IUserWithNewsRepository userWithNewsRepository) : IRequestHandler<GetUserWithNewsByIdQuery, UserWithNews>
    {
        private readonly IUserWithNewsRepository _userWithNewsRepository = userWithNewsRepository;

        public async Task<UserWithNews> Handle(GetUserWithNewsByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userWithNewsRepository.GetByIdAsync(request.Id);

            var ownNews = await _userWithNewsRepository.GetOwnNewsAsync(user.Id);
            ICollection<News> userNews = [];
            if (ownNews != null)
            {
                foreach (var news in ownNews)
                {
                    userNews.Add(news);
                }
            }

            UserWithNews userWithNews = new UserWithNews(
                user.Id,
                user.Role,
                user.CompleteName,
                user.Email,
                user.Password,
                user.Status,
                userNews
            );

            return userWithNews;
        }
    }
}
