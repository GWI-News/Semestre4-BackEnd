namespace GwiNews.Domain.Entities
{
    public class UserWithNews : User
    {
        public ICollection<News>? News { get; set; }

        public UserWithNews(UserRole? role, string? completeName, string? email, string? password, bool? status, ICollection<News>? news)
            : base(role, completeName, email, password, status)
        {
            News = news;
        }

        public UserWithNews(Guid? id, UserRole? role, string? completeName, string? email, string? password, bool? status, ICollection<News>? news)
            : base(id, role, completeName, email, password, status)
        {
            News = news;
        }
    }
}
