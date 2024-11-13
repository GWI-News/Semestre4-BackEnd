using GwiNews.Application.CQRS.UsersCQRS.Queries;
using GwiNews.Domain.Entities;
using MediatR;

namespace GwiNews.Application.CQRS.UserWithNewsCQRS.Queries
{
    public class GetUserWithNewsByIdQuery : GetUserByIdQuery, IRequest<UserWithNews>
    {
        public GetUserWithNewsByIdQuery(Guid? id)
            : base(id)
        {
            Id = id;
        }
    }
}
