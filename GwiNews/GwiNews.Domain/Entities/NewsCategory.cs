﻿using GwiNews.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace GwiNews.Domain.Entities
{
    public class NewsCategory
    {
        [Key]
        public Guid? Id { get; private set; }
        [Required]
        [StringLength(25)]
        public string? Name { get; private set; }
        public ICollection<News>? News { get; private set; }
        public ICollection<NewsSubcategory>? NewsSubcategories { get; private set; }

        public NewsCategory(Guid? id, string? name, ICollection<News>? news, ICollection<NewsSubcategory>? newsSubcategories)
        {
            if (id == null || id == Guid.Empty)
            {
                throw new DomainExceptionValidation("Id deve ser um GUID válido e não pode ser vazio ou nulo.");
            }
            ValidateDomain(name);
            Id = id;
            News = news;
            NewsSubcategories = newsSubcategories;
        }

        public NewsCategory(string? name, ICollection<News>? news, ICollection<NewsSubcategory>? newsSubcategories)
        {
            ValidateDomain(name);
            News = news;
            NewsSubcategories = newsSubcategories;
        }

        private void ValidateDomain(string? name)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "O nome da categoria é obrigatório.");
            DomainExceptionValidation.When(name!.Length > 25, "O nome da categoria não pode exceder 25 caracteres.");

            Name = name;
        }
    }
}
