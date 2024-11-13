namespace GwiNews.Application.CQRS.UserWithNewsCQRS.Commands
{
    public class UserWithNewsUpdateCommand : UserWithNewsCommands
    {
        public UserWithNewsUpdateCommand(Guid? id)
        {
            Id = id;
        }
    }
}
