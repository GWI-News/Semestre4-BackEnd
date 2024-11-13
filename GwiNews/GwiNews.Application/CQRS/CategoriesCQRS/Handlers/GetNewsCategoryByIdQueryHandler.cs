using GwiNews.Application.CQRS.CategoriesCQRS.Queries;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using MediatR;

namespace GwiNews.Application.CQRS.CategoriesCQRS.Handlers
{
    public class GetNewsCategoryByIdQueryHandler : IRequestHandler<GetNewsCategoryByIdQuery, NewsCategory>
    {
        private readonly INewsCategoryRepository _newsCategoryRepository;

        public GetNewsCategoryByIdQueryHandler(INewsCategoryRepository newsCategoryRepository)
        {
            _newsCategoryRepository = newsCategoryRepository;
        }

        public async Task<NewsCategory> Handle(GetNewsCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _newsCategoryRepository.GetByIdAsync(request.Id);
        }
    }
}
