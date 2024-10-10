using GwiNews.Application.Category.Commands;
using GwiNews.Domain.Entities;
using Infra.Data.Repositories;
using MediatR;

namespace GwiNews.Application.Categories.Handlers
{
    public class NewsCategoryCreateCommandHandler : IRequestHandler<NewsCategoryCreateCommand, NewsCategory>
    {
        private readonly NewsCategoryRepository _newsCategoryRepository;

        public NewsCategoryCreateCommandHandler(NewsCategoryRepository newsCategoryRepository)
        {
            _newsCategoryRepository = newsCategoryRepository;
        }

        public async Task<NewsCategory> Handle(NewsCategoryCreateCommand request, CancellationToken cancellationToken)
        {
            var category = new NewsCategory(request.Name);

            if (category == null)
            {
                throw new ApplicationException("Error creating category.");
            }

            return await _newsCategoryRepository.AddNewsCategory(category);
        }
    }
}
