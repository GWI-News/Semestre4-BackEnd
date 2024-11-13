using GwiNews.Application.CQRS.CategoriesCQRS.Queries;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using MediatR;

namespace GwiNews.Application.CQRS.CategoriesCQRS.Handlers
{
    public class GetNewsCategoriesQueryHandler : IRequestHandler<GetNewsCategoriesQuery, IEnumerable<NewsCategory>>
    {
        private readonly INewsCategoryRepository _newsCategoryRepository;

        public GetNewsCategoriesQueryHandler(INewsCategoryRepository newsCategoryRepository)
        {
            _newsCategoryRepository = newsCategoryRepository;
        }

        public async Task<IEnumerable<NewsCategory>> Handle(GetNewsCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _newsCategoryRepository.GetCategoriesAsync();
        }
    }
}
