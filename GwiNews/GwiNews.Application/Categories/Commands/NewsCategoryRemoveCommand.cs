using GwiNews.Domain.Entities;
using MediatR;

namespace GwiNews.Application.Category.Commands
{
    public class NewsCategoryRemoveCommand : IRequest<NewsCategory>
    {
        public Guid Id { get; set; }

        public NewsCategoryRemoveCommand(Guid id)
        {
            Id = id;
        }
    }
}
