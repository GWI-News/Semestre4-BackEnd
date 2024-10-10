using GwiNews.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GwiNews.Application.Users.Commands
{
    public abstract class UserCommands : IRequest<User>
    {
        public UserRole? Role { get; set; }
        public string? CompleteName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? Status { get; set; }
    }
}
