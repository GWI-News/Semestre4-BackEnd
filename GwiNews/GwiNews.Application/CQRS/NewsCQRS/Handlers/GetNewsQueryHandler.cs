using GwiNews.Application.CQRS.NewsCQRS.Queries;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using MediatR;

namespace GwiNews.Application.CQRS.NewsCQRS.Handlers
{
    public class GetNewsQueryHandler : IRequestHandler<GetNewsQuery, IEnumerable<News>>
    {
        private readonly INewsRepository _newsRepository;

        public GetNewsQueryHandler(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<IEnumerable<News>> Handle(GetNewsQuery request, CancellationToken cancellationToken)
        {
            return await _newsRepository.GetNewsAsync();
        }
    }
}
