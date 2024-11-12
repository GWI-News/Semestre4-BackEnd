namespace GwiNews.Application.CQRS.NewsCQRS.Commands
{
    public class NewsUpdateCommand : NewsCommands
    {
        public NewsUpdateCommand(Guid? id)
        {
            Id = id;
        }
    }
}
