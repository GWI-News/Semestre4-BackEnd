namespace GwiNews.Application.New.Commands
{
    public class NewsRemoveCommand : NewsCommands
    {
        public Guid Id { get; set; }
        public NewsRemoveCommand(Guid id)
        {
            Id = id;
        }
    }
}
