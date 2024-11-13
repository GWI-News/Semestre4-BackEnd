using GwiNews.Application.CQRS.UsersCQRS.Commands;
using GwiNews.Domain.Entities;
using MediatR;

namespace GwiNews.Application.CQRS.UserWithNewsCQRS.Commands
{
    public class UserWithNewsRemoveCommand : UserRemoveCommand, IRequest<UserWithNews>
    {
        public UserWithNewsRemoveCommand(Guid? id)
            : base(id)
        {
            Id = id;
        }
    }
}
