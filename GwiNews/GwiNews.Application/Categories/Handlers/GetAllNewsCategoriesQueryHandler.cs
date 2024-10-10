using GwiNews.Application.Categories.Queries;
using GwiNews.Domain.Entities;
using Interfaces;
using MediatR;

namespace GwiNews.Application.Categories.Handlers
{
    public class GetAllNewsCategoriesQueryHandler : IRequestHandler<GetAllNewsCategoriesQuery, IEnumerable<NewsCategory>>
    {
        private readonly INewsCategoryRepository _newsCategoryRepository;

        public GetAllNewsCategoriesQueryHandler(INewsCategoryRepository newsCategoryRepository)
        {
            _newsCategoryRepository = newsCategoryRepository;
        }

        public async Task<IEnumerable<NewsCategory>> Handle(GetAllNewsCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _newsCategoryRepository.GetAllWithRelatedData();
        }
    }
}
