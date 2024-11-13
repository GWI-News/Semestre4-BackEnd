using MediatR;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Application.CQRS.NewsCQRS.Commands;

namespace GwiNews.Application.CQRS.NewsCQRS.Handlers
{
    public class NewsCreateCommandHandler : IRequestHandler<NewsCreateCommand, News>
    {
        private readonly INewsRepository _newsRepository;

        public NewsCreateCommandHandler(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<News> Handle(NewsCreateCommand request, CancellationToken cancellationToken)
        {
            var newNews = new News(request.Id, request.Status ?? NewsStatus.Rascunho, request.NewsUrl, request.Title, request.Subtitle, request.NewsBody, request.ImageUrl, request.PublicationDate, request.Author, request.Editor, request.NewsCategory, request.NewsSubcategories, request.FavoritedBy);

            var createdNews = await _newsRepository.CreateAsync(newNews);

            return createdNews;
        }
    }
}
