using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwiNews.Domain.Entities
{
    public enum NewsStatus
    {
        Publicada = 0,
        EmRevisao = 1,
        Rascunho = 2,
        Inativa = 3
    }

    //Atributos
    public class News
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public NewsStatus Status { get; set; }

        public string NewsUrl { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string NewsBody { get; set; }

        public string ImageUrl { get; set; }

        public DateTime PublicationDate { get; set; }

        //public UserWithNews Author { get; set; }

        //public UserWithNews Editor { get; set; }

        public NewsCategory newsCategory { get; set; }

        public ICollection<NewsSubcategory> NewsSubcategories { get; set; } = new List<NewsSubcategory>();

        public ICollection<ReaderUser> FavoritedByUsers { get; set; } = new List<ReaderUser>();

        //Construtores

        public News() { }

        public News(Guid id, NewsStatus status, string newsUrl, string title, string subtitle, string newsBody, string imageUrl, DateTime publicationDate, UserWithNews author, UserWithNews editor, NewsCategory newsCategory)
        {
            Id = id;
            Status = status;
            NewsUrl = newsUrl;
            Title = title;
            Subtitle = subtitle;
            NewsBody = newsBody;
            ImageUrl = imageUrl;
            PublicationDate = publicationDate;
            Author = author;
            Editor = editor;
            this.newsCategory = newsCategory;
        }
    }
}
