using GwiNews.Application.CQRS.UsersCQRS.Commands;
using GwiNews.Domain.Entities;
using MediatR;

namespace GwiNews.Application.CQRS.UserWithNewsCQRS.Commands
{
    public abstract class UserWithNewsCommands : UserCommands, IRequest<UserWithNews>
    {
        public ICollection<News>? News { get; set; }
    }
}
