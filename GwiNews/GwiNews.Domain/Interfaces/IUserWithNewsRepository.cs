using GwiNews.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GwiNews.Infra.Data.Interfaces
{
    public interface IUserWithNewsRepository
    {
        Task<UserWithNews> GetByIdAsync(Guid id);
        Task<IEnumerable<UserWithNews>> GetAllAsync();
        Task AddAsync(UserWithNews userWithNews);
        Task UpdateAsync(UserWithNews userWithNews);
        Task DeleteAsync(Guid id);
    }
}
