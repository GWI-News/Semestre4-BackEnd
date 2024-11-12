using MediatR;
using GwiNews.Domain.Entities;

namespace GwiNews.Application.CQRS.UsersCQRS.Commands
{
    public abstract class UserCommands : IRequest<User>
    {
        public Guid? Id { get; set; }
        public string? CompleteName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public UserRole? Role { get; set; }
        public bool? Status { get; set; }
    }
}
