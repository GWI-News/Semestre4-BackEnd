using GwiNews.Domain.Entities;
using MediatR;

namespace GwiNews.Application.CQRS.NewsCQRS.Commands
{
    public class NewsRemoveCommand : IRequest<News>
    {
        public Guid? Id { get; set; }

        public NewsRemoveCommand(Guid? id)
        {
            Id = id;
        }
    }
}
