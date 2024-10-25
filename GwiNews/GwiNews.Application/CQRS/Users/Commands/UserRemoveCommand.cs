using GwiNews.Domain.Entities;
using MediatR;

namespace GwiNews.Application.CQRS.Users.Commands
{
    public class UserRemoveCommand : IRequest<User>
    {
        public Guid? Id { get; set; }

        public UserRemoveCommand(Guid? id)
        {
            Id = id;
        }
    }
}
