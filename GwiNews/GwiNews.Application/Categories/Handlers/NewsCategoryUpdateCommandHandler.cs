using GwiNews.Application.Category.Commands;
using GwiNews.Domain.Entities;
using Interfaces;
using MediatR;

namespace GwiNews.Application.Categories.Handlers
{
    public class NewsCategoryUpdateCommandHandler : IRequestHandler<NewsCategoryUpdateCommand, NewsCategory>
    {
        private readonly INewsCategoryRepository _newsCategoryRepository;

        public NewsCategoryUpdateCommandHandler(INewsCategoryRepository newsCategoryRepository)
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

            return await _newsCategoryRepository.UpdateNewsCategory(category);
        }
    }
}
