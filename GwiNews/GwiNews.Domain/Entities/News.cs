using GwiNews.Domain.Validation;

namespace GwiNews.Domain.Entities
{
    public enum NewsStatus
    {
        Publicada = 0,
        EmRevisao = 1,
        Rascunho = 2,
        Inativa = 3
    }

    // Atributos
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

        // Adicionando a propriedade UserId
        public Guid UserId { get; set; }

        // Propriedade de navegação para o autor da notícia
        public UserWithNews UserWithNews { get; set; }

        public NewsCategory NewsCategory { get; set; }

        // Construtores
        public News() { }

        public News(Guid id, NewsStatus status, string newsUrl, string title, string subtitle, string newsBody, string imageUrl, DateTime publicationDate, Guid userId, NewsCategory newsCategory)
        {
            Id = id;
            Status = status;
            NewsUrl = newsUrl;
            Title = title;
            Subtitle = subtitle;
            NewsBody = newsBody;
            ImageUrl = imageUrl;
            PublicationDate = publicationDate;
            UserId = userId; // Inicializa UserId
            this.NewsCategory = newsCategory;
        }

        // Validações
        public void ValidateDomain(NewsStatus status, string newsUrl, string title, string subtitle, string newsBody, string imageUrl, DateTime publicationDate, Guid userId, NewsCategory newsCategory)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(newsUrl) || newsUrl.Length > 255, "A URL da notícia é obrigatória e não pode exceder 255 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(title) || title.Length > 75, "O título da notícia é obrigatório e não pode exceder 75 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(subtitle) || subtitle.Length > 255, "O subtítulo da notícia é obrigatório e não pode exceder 255 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(newsBody) || newsBody.Length > 65535, "O corpo da notícia é obrigatório e não pode exceder 65.535 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(imageUrl) || imageUrl.Length > 555, "A URL da imagem é obrigatória e não pode exceder 555 caracteres.");
            DomainExceptionValidation.When(publicationDate == null, "A data de publicação é obrigatória.");
            DomainExceptionValidation.When(userId == Guid.Empty, "O autor é obrigatório."); // Validação do UserId
            DomainExceptionValidation.When(newsCategory == null, "A categoria da notícia é obrigatória.");

            Status = status;
            NewsUrl = newsUrl;
            Title = title;
            Subtitle = subtitle;
            NewsBody = newsBody;
            ImageUrl = imageUrl;
            PublicationDate = publicationDate;
            UserId = userId; // Atribui UserId
            this.NewsCategory = newsCategory;

            // As validações foram entregues na mesma branch da criação da entidade News
        }
    }
}
