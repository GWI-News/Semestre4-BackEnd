using GwiNews.Application.CQRS.CategoriesCQRS.Commands;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using MediatR;

namespace GwiNews.Application.CQRS.CategoriesCQRS.Handlers
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
            var category = await _newsCategoryRepository.GetByIdAsync(request.Id);

            if (category == null)
            {
                throw new ApplicationException("News category not found.");
            }

            return await _newsCategoryRepository.UpdateAsync(category);
        }
    }
}
