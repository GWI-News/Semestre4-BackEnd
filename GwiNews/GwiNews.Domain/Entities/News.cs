using GwiNews.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace GwiNews.Domain.Entities
{
    public enum NewsStatus
    {
        Publicada = 0,
        EmRevisao = 1,
        Rascunho = 2,
        Inativa = 3
    }

    public class News
    {
        [Key]
        public Guid? Id { get; private set; }
        [Required]
        public NewsStatus? Status { get; private set; }
        [Required]
        public string? NewsUrl { get; private set; }
        [Required]
        public string? Title { get; private set; }
        [Required]
        public string? Subtitle { get; private set; }
        [Required]
        public string? NewsBody { get; private set; }
        [Required]
        public string? ImageUrl { get; private set; }
        [Required]
        public DateTime? PublicationDate { get; private set; }
        [Required]
        public UserWithNews? Author { get; private set; }
        [Required]
        public UserWithNews? Editor { get; private set; }
        [Required]
        public NewsCategory? NewsCategory { get; private set; }
        //[Required]
        //public ICOllection<NewsSubcategory>? NewsSubcategories { get; private set; }
        //public ICollection<UserReader>? FavoritedBy { get; private set; }

        public News(Guid? id, NewsStatus? newsStatus, string? newsUrl, string? title, string? subtitle, string? newsBody, string? imageUrl, DateTime? publicationDate, UserWithNews? author, UserWithNews? editor, NewsCategory? newsCategory)
        {
            if (id == null || id == Guid.Empty)
            {
                throw new DomainExceptionValidation("Id deve ser um GUID válido e não pode ser vazio ou nulo.");
            }
            ValidateDomain(newsStatus, newsUrl, title, subtitle, newsBody, imageUrl, publicationDate, author, editor, newsCategory);
            Id = id;
        }

        public News(NewsStatus? newsStatus, string? newsUrl, string? title, string? subtitle, string? newsBody, string? imageUrl, DateTime? publicationDate, UserWithNews? author, UserWithNews? editor, NewsCategory? newsCategory)
        {
            ValidateDomain(newsStatus, newsUrl, title, subtitle, newsBody, imageUrl, publicationDate, author, editor, newsCategory);
        }

        private void ValidateDomain(NewsStatus? newsStatus, string? newsUrl, string? title, string? subtitle, string? newsBody, string? imageUrl, DateTime? publicationDate, UserWithNews? author, UserWithNews? editor, NewsCategory? newsCategory)
        {
            DomainExceptionValidation.When(newsStatus == null, "O status da notícia é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(newsUrl) || newsUrl.Length > 255, "A URL da notícia é obrigatória e não pode exceder 255 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(title) || title.Length > 75, "O título é obrigatório e não pode exceder 75 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(subtitle) || subtitle.Length > 255, "O subtítulo é obrigatório e não pode exceder 255 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(newsBody) || newsBody.Length > 65535, "O corpo da notícia é obrigatório e não pode exceder 65.535 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(imageUrl) || imageUrl.Length > 555, "A URL da imagem é obrigatória e não pode exceder 555 caracteres.");
            DomainExceptionValidation.When(publicationDate == null, "A data de publicação é obrigatória.");
            DomainExceptionValidation.When(author == null, "O autor da notícia é obrigatório.");
            DomainExceptionValidation.When(editor == null, "O editor da notícia é obrigatório.");
            DomainExceptionValidation.When(newsCategory == null, "A categoria da notícia é obrigatória.");

            Status = newsStatus;
            NewsUrl = newsUrl;
            Title = title;
            Subtitle = subtitle;
            NewsBody = newsBody;
            ImageUrl = imageUrl;
            PublicationDate = publicationDate;
            Author = author;
            Editor = editor;
            NewsCategory = newsCategory;
        }
    }
}
