using GwiNews.Domain.Entities;
using GwiNews.Domain.Validation;

namespace GwiNews.Domain.Test
{
    public class NewsSubcategoryTests
    {
        [Fact]
        public void Constructor_ValidParameters_ShouldCreateNewsSubcategory()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Valid Name";
            var newsCategory = new NewsCategory(Guid.NewGuid(), "Category Name", new List<News>(), null);
            var news = new List<News>();

            // Act
            var newsSubcategory = new NewsSubcategory(id, name, newsCategory, news);

            // Assert
            Assert.NotNull(newsSubcategory);
            Assert.Equal(id, newsSubcategory.Id);
            Assert.Equal(name, newsSubcategory.Name);
            Assert.Equal(newsCategory, newsSubcategory.NewsCategory);
            Assert.Equal(news, newsSubcategory.News);
        }

        [Fact]
        public void Constructor_InvalidId_ShouldThrowDomainException()
        {
            // Arrange
            var invalidId = Guid.Empty;
            var name = "Valid Name";
            var newsCategory = new NewsCategory(Guid.NewGuid(), "Category Name", null, null);
            var news = new List<News>();

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() =>
                new NewsSubcategory(invalidId, name, newsCategory, news));

            Assert.Equal("Id deve ser um GUID válido e não pode ser vazio ou nulo.", exception.Message);
        }

        [Fact]
        public void Constructor_EmptyName_ShouldThrowDomainException()
        {
            // Arrange
            var id = Guid.NewGuid();
            string name = "";
            var newsCategory = new NewsCategory(Guid.NewGuid(), "Category Name", null, null);
            var news = new List<News>();

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() =>
                new NewsSubcategory(id, name, newsCategory, news));

            Assert.Equal("O nome é obrigatório e não pode exceder 55 caracteres.", exception.Message);
        }

        [Fact]
        public void Constructor_NameExceedsMaxLength_ShouldThrowDomainException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = new string('A', 56);
            var newsCategory = new NewsCategory(Guid.NewGuid(), "Category Name", null, null);
            var news = new List<News>();

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() =>
                new NewsSubcategory(id, name, newsCategory, news));

            Assert.Equal("O nome é obrigatório e não pode exceder 55 caracteres.", exception.Message);
        }

        [Fact]
        public void Constructor_NullNewsCategory_ShouldThrowDomainException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Valid Name";
            NewsCategory newsCategory = null;
            var news = new List<News>();

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() =>
                new NewsSubcategory(id, name, newsCategory, news));

            Assert.Equal("A categoria é obrigatória.", exception.Message);
        }
    }
}
