using GwiNews.Application.CQRS.NewsCQRS.Commands;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using MediatR;

namespace GwiNews.Application.CQRS.NewsCQRS.Handlers
{
    public class NewsUpdateCommandHandler : IRequestHandler<NewsUpdateCommand, News>
    {
        private readonly INewsRepository _newsRepository;

        public NewsUpdateCommandHandler(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<News> Handle(NewsUpdateCommand request, CancellationToken cancellationToken)
        {
            var news = await _newsRepository.GetByIdAsync(request.Id);

            if (news == null)
            {
                throw new ApplicationException("News item not found.");
            }

            return await _newsRepository.UpdateAsync(news);
        }
    }
}
