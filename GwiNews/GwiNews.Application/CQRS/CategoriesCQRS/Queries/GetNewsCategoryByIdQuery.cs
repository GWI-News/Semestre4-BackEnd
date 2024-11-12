using GwiNews.Domain.Entities;
using MediatR;

namespace GwiNews.Application.CQRS.CategoriesCQRS.Queries
{
    public class GetNewsCategoryByIdQuery : IRequest<NewsCategory>
    {
        public Guid? Id { get; set; }

        public GetNewsCategoryByIdQuery(Guid? id)
        {
            Id = id;
        }
    }
}
