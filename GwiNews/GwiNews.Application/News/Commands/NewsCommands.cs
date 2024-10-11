using GwiNews.Domain.Entities;
using MediatR;


namespace GwiNews.Application.News.Commands
{
    public abstract class NewsCommands : IRequest<News>
    {
        public NewsStatus Status { get; set; }
        public string NewsUrl { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string NewsBody { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublicationDate { get; set; }

        /*public System.Guid UserId { get; set; }
        public NewsCategory NewsCategory { get; set; }*/
    }
}
