using GwiNews.Application.Categories.Queries;
using GwiNews.Domain.Entities;
using Interfaces;
using MediatR;

namespace GwiNews.Application.Categories.Handlers
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
            var category = await _newsCategoryRepository.GetByIdWithRelatedData(request.Id);

            if (category == null)
            {
                throw new ApplicationException($"Category with Id {request.Id} not found.");
            }

            return category;
        }
    }
}
