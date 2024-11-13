using GwiNews.Application.CQRS.NewsCQRS.Queries;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using MediatR;

namespace GwiNews.Application.CQRS.NewsCQRS.Handlers
{
    public class GetNewsByIdQueryHandler : IRequestHandler<GetNewsByIdQuery, News>
    {
        private readonly INewsRepository _newsRepository;

        public GetNewsByIdQueryHandler(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<News> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
        {
            return await _newsRepository.GetByIdAsync(request.Id);
        }
    }
}
