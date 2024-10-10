using GwiNews.Domain.Entities;
using MediatR;

namespace GwiNews.Application.Category.Commands
{
    public abstract class NewsCategoryCommand : IRequest<NewsCategory>
    {
        public string Name { get; set; }
    }
}
