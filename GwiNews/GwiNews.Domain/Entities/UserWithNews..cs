using System;
using System.Collections.Generic;

namespace GwiNews.Domain.Entities
{
    public class UserWithNews : User
    {
      
        public ICollection<News>? News { get; set; }

        public UserWithNews(UserRole? role, string? completeName, string? email, string? password, bool? status)
            : base(role, completeName, email, password, status)
        {
            News = new List<News>();
        }

        public UserWithNews(Guid? id, UserRole? role, string? completeName, string? email, string? password, bool? status)
            : base(id, role, completeName, email, password, status)
        {
            News = new List<News>(); 
        }
    }
}
