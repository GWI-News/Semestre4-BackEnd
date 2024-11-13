using MediatR;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Application.CQRS.CategoriesCQRS.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace GwiNews.Application.CQRS.CategoriesCQRS.Handlers
{
    public class NewsCategoryRemoveCommandHandler : IRequestHandler<NewsCategoryRemoveCommand, NewsCategory>
    {
        private readonly INewsCategoryRepository _newsCategoryRepository;

        public NewsCategoryRemoveCommandHandler(INewsCategoryRepository newsCategoryRepository)
        {
            _newsCategoryRepository = newsCategoryRepository;
        }

        public async Task<NewsCategory> Handle(NewsCategoryRemoveCommand request, CancellationToken cancellationToken)
        {
            var category = await _newsCategoryRepository.GetByIdAsync(request.Id);

            if (category == null)
                return null;

            var removedCategory = await _newsCategoryRepository.RemoveAsync(category);

            return removedCategory;
        }
    }
}
