using MediatR;
using GwiNews.Domain.Entities;

namespace GwiNews.Application.CQRS.NewsCQRS.Commands
{
    public abstract class NewsCommands : IRequest<News>
    {
        public Guid? Id { get; set; }
        public NewsStatus? Status { get; set; }
        public string? NewsUrl { get; set; }
        public string? Title { get; set; }
        public string? Subtitle { get; set; }
        public string? NewsBody { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? PublicationDate { get; set; }
        public UserWithNews? Author { get; set; }
        public UserWithNews? Editor { get; set; }
        public NewsCategory? NewsCategory { get; set; }
        public ICollection<NewsSubcategory>? NewsSubcategories { get; set; }
    }
}
