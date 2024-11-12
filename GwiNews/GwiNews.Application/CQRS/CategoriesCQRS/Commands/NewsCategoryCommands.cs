using MediatR;
using GwiNews.Domain.Entities;

namespace GwiNews.Application.CQRS.CategoriesCQRS.Commands
{
    public abstract class NewsCategoryCommands : IRequest<NewsCategory>
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public ICollection<News>? News { get; set; }
        public ICollection<NewsSubcategory>? NewsSubcategories { get; set; }
    }
}
