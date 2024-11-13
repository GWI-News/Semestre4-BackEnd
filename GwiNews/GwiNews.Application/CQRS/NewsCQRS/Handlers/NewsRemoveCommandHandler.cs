using MediatR;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Application.CQRS.NewsCQRS.Commands;

namespace GwiNews.Application.CQRS.NewsCQRS.Handlers
{
    public class NewsRemoveCommandHandler : IRequestHandler<NewsRemoveCommand, News>
    {
        private readonly INewsRepository _newsRepository;

        public NewsRemoveCommandHandler(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<News> Handle(NewsRemoveCommand request, CancellationToken cancellationToken)
        {
            var news = await _newsRepository.GetByIdAsync(request.Id);

            if (news == null)
                return null;

            var removedNews = await _newsRepository.RemoveAsync(news);

            return removedNews;
        }
    }
}
