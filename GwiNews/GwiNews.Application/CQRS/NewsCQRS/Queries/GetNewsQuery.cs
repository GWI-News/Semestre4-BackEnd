using GwiNews.Domain.Entities;
using MediatR;

namespace GwiNews.Application.CQRS.NewsCQRS.Queries
{
    public class GetNewsQuery : IRequest<IEnumerable<News>>
    {
    }
}
