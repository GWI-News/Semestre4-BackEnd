using GwiNews.Application.Category.Commands;
using GwiNews.Domain.Entities;
using Interfaces;
using MediatR;

namespace GwiNews.Application.Categories.Handlers
{
    public class NewsCategoryCreateCommandHandler : IRequestHandler<NewsCategoryCreateCommand, NewsCategory>
    {
        private readonly INewsCategoryRepository _newsCategoryRepository;

        public NewsCategoryCreateCommandHandler(INewsCategoryRepository newsCategoryRepository)
        {
            _newsCategoryRepository = newsCategoryRepository;
        }

        public async Task<NewsCategory> Handle(NewsCategoryCreateCommand request, CancellationToken cancellationToken)
        {
            var category = new NewsCategory(request.Name, null);

            if (category == null)
            {
                throw new ApplicationException("Error creating category.");
            }

            return await _newsCategoryRepository.AddNewsCategory(category);
        }
    }
}
