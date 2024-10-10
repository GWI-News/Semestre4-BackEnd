using GwiNews.Application.Category.Commands;
using GwiNews.Domain.Entities;
using Infra.Data.Repositories;
using MediatR;

namespace GwiNews.Application.Categories.Handlers
{
    public class NewsCategoryUpdateCommandHandler : IRequestHandler<NewsCategoryUpdateCommand, NewsCategory>
    {
        private readonly NewsCategoryRepository _newsCategoryRepository;

        public NewsCategoryUpdateCommandHandler(NewsCategoryRepository newsCategoryRepository)
        {
            _newsCategoryRepository = newsCategoryRepository;
        }

        public async Task<NewsCategory> Handle(NewsCategoryUpdateCommand request, CancellationToken cancellationToken)
        {
            var category = await _newsCategoryRepository.GetNewsCategoryById(request.Id);

            if (category == null)
            {
                throw new ApplicationException("Category not found.");
            }

            category.Name = request.Name;

            return await _newsCategoryRepository.UpdateNewsCategory(category);
        }
    }
}
