using GwiNews.Domain.Entities;
using MediatR;

namespace GwiNews.Application.CQRS.NewsCQRS.Queries
{
    public class GetNewsByIdQuery : IRequest<News>
    {
        public Guid? Id { get; set; }

        public GetNewsByIdQuery(Guid? id)
        {
            Id = id;
        }
    }
}
