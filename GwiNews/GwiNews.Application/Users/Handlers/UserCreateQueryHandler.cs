//using GwiNews.Application.Users.Commands;
//using GwiNews.Domain.Entities;
//using GwiNews.Domain.Interfaces;
//using MediatR;

//namespace GwiNews.Application.Users.Handlers
//{
//    public class UserCreateQueryHandler : IRequestHandler<UserCreateCommand, User>
//    {
//        private readonly IUserRepository _userRepository;

//        public UserCreateQueryHandler(IUserRepository userRepository)
//        {
//            _userRepository = userRepository;
//        }

//        public async Task<User> Handle(UserCreateCommand request, CancellationToken cancellationToken)
//        {
//            var user = new User(request.Role, request.CompleteName, request.Email, request.Password, request.Status);

//            if (user == null)
//            {
//                throw new ApplicationException($"Error creating entity.");
//            }
//            else
//            {
//                return await _userRepository.CreateUserAsync(user);
//            }
//        }
//    }
//}
