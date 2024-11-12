namespace GwiNews.Application.CQRS.CategoriesCQRS.Commands
{
    public class NewsCategoryUpdateCommand : NewsCategoryCommands
    {
        public NewsCategoryUpdateCommand(Guid? id)
        {
            Id = id;
        }
    }
}
