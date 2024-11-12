using GwiNews.Domain.Entities;
using MediatR;

namespace GwiNews.Application.CQRS.UsersCQRS.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<User>>
    {
    }
}
