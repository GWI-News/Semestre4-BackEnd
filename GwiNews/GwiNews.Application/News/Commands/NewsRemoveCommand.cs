namespace GwiNews.Application.News.Commands
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
