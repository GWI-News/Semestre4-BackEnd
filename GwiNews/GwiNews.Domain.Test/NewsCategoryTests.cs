using GwiNews.Domain.Entities;
using GwiNews.Domain.Validation;

namespace GwiNews.Domain.Test
{
    public class NewsCategoryTests
    {
        [Fact]
        public void Create_NewsCategory_WithValidParameters_ShouldNotThrowException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Tecnologia";
            var newsList = new List<News>();
            var subcategories = new List<NewsSubcategory>();

            // Act
            var newsCategory = new NewsCategory(id, name, newsList, subcategories);

            // Assert
            Assert.Equal(id, newsCategory.Id);
            Assert.Equal(name, newsCategory.Name);
            Assert.Equal(newsList, newsCategory.News);
            Assert.Equal(subcategories, newsCategory.NewsSubcategories);
        }

        [Fact]
        public void Create_NewsCategory_WithEmptyGuid_ShouldThrowDomainExceptionValidation()
        {
            // Arrange
            var invalidId = Guid.Empty;
            var name = "Tecnologia";
            var newsList = new List<News>();
            var subcategories = new List<NewsSubcategory>();

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() =>
                new NewsCategory(invalidId, name, newsList, subcategories));
            Assert.Equal("Id deve ser um GUID válido e não pode ser vazio ou nulo.", exception.Message);
        }

        [Fact]
        public void Create_NewsCategory_WithNullName_ShouldThrowDomainExceptionValidation()
        {
            // Arrange
            var id = Guid.NewGuid();
            string? invalidName = null;
            var newsList = new List<News>();
            var subcategories = new List<NewsSubcategory>();

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() =>
                new NewsCategory(id, invalidName, newsList, subcategories));
            Assert.Equal("O nome da categoria é obrigatório.", exception.Message);
        }

        [Fact]
        public void Create_NewsCategory_WithLongName_ShouldThrowDomainExceptionValidation()
        {
            // Arrange
            var id = Guid.NewGuid();
            var invalidName = new string('A', 26);
            var newsList = new List<News>();
            var subcategories = new List<NewsSubcategory>();

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() =>
                new NewsCategory(id, invalidName, newsList, subcategories));
            Assert.Equal("O nome da categoria não pode exceder 25 caracteres.", exception.Message);
        }

        [Fact]
        public void Create_NewsCategory_WithoutId_ShouldNotThrowException()
        {
            // Arrange
            var name = "Política";
            var newsList = new List<News>();
            var subcategories = new List<NewsSubcategory>();

            // Act
            var newsCategory = new NewsCategory(name, newsList, subcategories);

            // Assert
            Assert.Null(newsCategory.Id);
            Assert.Equal(name, newsCategory.Name);
            Assert.Equal(newsList, newsCategory.News);
            Assert.Equal(subcategories, newsCategory.NewsSubcategories);
        }
    }
}
