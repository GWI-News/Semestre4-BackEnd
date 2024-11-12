namespace GwiNews.Application.CQRS.UsersCQRS.Commands
{
    public class UserUpdateCommand : UserCommands
    {
        public UserUpdateCommand(Guid? id)
        {
            Id = id;
        }
    }
}
