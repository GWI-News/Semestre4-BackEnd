using GwiNews.Domain.Entities;
using MediatR;

namespace GwiNews.Application.CQRS.CategoriesCQRS.Queries
{
    public class GetNewsCategoriesQuery : IRequest<IEnumerable<NewsCategory>>
    {
    }
}
