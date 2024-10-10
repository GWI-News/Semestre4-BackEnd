namespace GwiNews.Application.Users.Commands
{
    public class UserRemoveCommand : UserCommands
    {
        public Guid Id { get; set; }
        public UserRemoveCommand(Guid id)
        {
            Id = id;
        }
    }
}
