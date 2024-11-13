using GwiNews.Application.CQRS.UsersCQRS.Queries;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using MediatR;

namespace GwiNews.Application.CQRS.UsersCQRS.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetByIdAsync(request.Id);
        }
    }
}
