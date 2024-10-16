//using GwiNews.Domain.Entities;
//using GwiNews.Domain.Interfaces;
//using GwiNews.Infra.Data.Context;
//using Microsoft.EntityFrameworkCore;

//namespace GwiNews.Infra.Data.Repositories
//{
//    public class UserRepository : IUserRepository
//    {
//        private readonly ApplicationDbContext _userContext;

//        public UserRepository(ApplicationDbContext context)
//        {
//            _userContext = context;
//        }

//        public async Task<User> GetByIdUserAsync(Guid? id)
//        {
//            return await _userContext.Users.FindAsync(id);
//        }

//        public async Task<IEnumerable<User>> GetAllUserAsync()
//        {
//            return await _userContext.Users.ToListAsync();
//        }

//        public async Task<User> CreateUserAsync(User user)
//        {
//            await _userContext.Users.AddAsync(user);
//            await _userContext.SaveChangesAsync();
//            return user;
//        }

//        public async Task<User> UpdateUserAsync(User user)
//        {
//            _userContext.Users.Update(user);
//            await _userContext.SaveChangesAsync();
//            return user;
//        }

//        public async Task<User> DeleteUserAsync(Guid? id)
//        {
//            var user = await GetByIdUserAsync(id);
//            if (user == null) return null;

//            _userContext.Users.Remove(user);
//            await _userContext.SaveChangesAsync();
//            return user;
//        }

//        public async Task<User> GetByEmailUserAsync(string email)
//        {
//            return await _userContext.Users.FirstOrDefaultAsync(u => u.Email == email);
//        }

//        public async Task<User> StatusChangeUserAsync(Guid id)
//        {
//            var user = await GetByIdUserAsync(id);
//            if (user == null) return null;

//            user.ActiveUser(user.Status);
//            await UpdateUserAsync(user);
//            return user;
//        }
//    }
//}
