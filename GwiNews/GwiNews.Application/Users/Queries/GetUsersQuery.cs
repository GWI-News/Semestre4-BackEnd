using GwiNews.Domain.Entities;
using MediatR;

namespace GwiNews.Application.Users.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<User>>
    {
    }
}
