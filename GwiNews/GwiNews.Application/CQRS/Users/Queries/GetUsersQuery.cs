using GwiNews.Domain.Entities;
using MediatR;

namespace GwiNews.Application.CQRS.Users.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<User>>
    {
    }
}
