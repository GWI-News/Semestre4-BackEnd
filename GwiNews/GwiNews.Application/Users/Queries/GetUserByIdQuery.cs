using GwiNews.Domain.Entities;
using MediatR;

namespace GwiNews.Application.Users.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public Guid? Id { get; set; }

        public GetUserByIdQuery(Guid? id)
        {
            Id = id;
        }
    }
}
