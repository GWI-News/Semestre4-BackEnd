using MediatR;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Application.CQRS.CategoriesCQRS.Commands;

namespace GwiNews.Application.CQRS.CategoriesCQRS.Handlers
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
            var newCategory = new NewsCategory(request.Id, request.Name, request.News, request.NewsSubcategories);

            var createdCategory = await _newsCategoryRepository.CreateAsync(newCategory);

            return createdCategory;
        }
    }
}
