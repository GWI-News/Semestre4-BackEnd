namespace GwiNews.Application.CQRS.Users.Commands
{
    public class UserUpdateCommand : UserCommands
    {
        public UserUpdateCommand(Guid? id)
        {
            Id = id;
        }
    }
}
