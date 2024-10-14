using GwiNews.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace GwiNews.Domain.Entities
{
    public class NewsSubcategory
    {
        [Key]
        public Guid? Id { get; private set; }
        [Required]
        [StringLength(55)]
        public string? Name { get; private set; }
        [Required]
        public NewsCategory? NewsCategory { get; private set; }
        public ICollection<News>? News { get; private set; }

        public NewsSubcategory(string? name, NewsCategory? newsCategory, ICollection<News>? news)
        {
            Validation(name, newsCategory);
            News = news;
        }

        public NewsSubcategory(Guid? id, string? name, NewsCategory? newsCategory, ICollection<News>? news)
       {
            if (id == null || id == Guid.Empty)
            {
                throw new DomainExceptionValidation("Id deve ser um GUID válido e não pode ser vazio ou nulo.");
            }
            Validation(name, newsCategory);
            Id = id;
            News = news;
        }
       
       private void Validation(string? name, NewsCategory? newsCategory)
       {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name) || name.Length > 55, "O nome é obrigatório e não pode exceder 55 caracteres.");
            DomainExceptionValidation.When(newsCategory == null, "A categoria é obrigatória.");

            Name = name;
            NewsCategory = newsCategory;
        }
    }
}
