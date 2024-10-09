using System.Collections.Generic;

namespace GwiNews.Domain.Entities
{
    public class UserWithNews : User
    {
        public UserWithNews(UserRole? role, string? completeName, string? email, string? password, bool? status)
            : base(role, completeName, email, password, status)
        {
            
        }

        public UserWithNews(Guid? id, UserRole? role, string? completeName, string? email, string? password, bool? status)
            : base(id, role, completeName, email, password, status)
        {

        }
    }
}
