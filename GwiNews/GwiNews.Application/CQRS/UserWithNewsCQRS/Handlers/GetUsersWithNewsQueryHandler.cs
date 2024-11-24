using GwiNews.Application.CQRS.UserWithNewsCQRS.Queries;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using MediatR;

namespace GwiNews.Application.CQRS.UserWithNewsCQRS.Handlers
{
    public class GetUsersWithNewsQueryHandler : IRequestHandler<GetUsersWithNewsQuery, IEnumerable<UserWithNews>>
    {
        private readonly IUserWithNewsRepository _userWithNewsRepository;

        public GetUsersWithNewsQueryHandler(IUserWithNewsRepository userWithNewsRepository)
        {
            _userWithNewsRepository = userWithNewsRepository;
        }

        public async Task<IEnumerable<UserWithNews>> Handle(GetUsersWithNewsQuery request, CancellationToken cancellationToken)
        {
            var users = await _userWithNewsRepository.GetUsersAsync();

            IEnumerable<UserWithNews> result = new List<UserWithNews>();
            foreach (var user in users) {
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
                result.Append(userWithNews);
            }

            return result;
        }
    }
}
