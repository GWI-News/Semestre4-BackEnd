using GwiNews.Domain.Entities;
using GwiNews.Domain.Validation;

namespace GwiNews.Domain.Test
{
    public class NewsTests
    {
        [Fact]
        public void CreateNews_ValidParameters_ShouldCreateNews()
        {
            // Arrange
            var id = Guid.NewGuid();
            var status = NewsStatus.Publicada;
            var newsUrl = "https://validurl.com";
            var title = "Valid Title";
            var subtitle = "Valid Subtitle";
            var newsBody = new string('a', 1000);
            var imageUrl = "https://validimage.com";
            var publicationDate = DateTime.UtcNow;
            var author = new UserWithNews(UserRole.Autor, "Valid Author", "author@valid.com", "ValidPassword123", true, null);
            var editor = new UserWithNews(UserRole.Editor, "Valid Editor", "editor@valid.com", "ValidPassword123", true, null);
            var category = new NewsCategory("Valid Category", null, null);
            var subcategories = new List<NewsSubcategory>();

            // Act
            var news = new News(id, status, newsUrl, title, subtitle, newsBody, imageUrl, publicationDate, author, editor, category, subcategories, null);

            // Assert
            Assert.NotNull(news);
            Assert.Equal(id, news.Id);
            Assert.Equal(status, news.Status);
            Assert.Equal(newsUrl, news.NewsUrl);
            Assert.Equal(title, news.Title);
            Assert.Equal(subtitle, news.Subtitle);
            Assert.Equal(newsBody, news.NewsBody);
            Assert.Equal(imageUrl, news.ImageUrl);
            Assert.Equal(publicationDate, news.PublicationDate);
            Assert.Equal(author, news.Author);
            Assert.Equal(editor, news.Editor);
            Assert.Equal(category, news.NewsCategory);
        }

        [Fact]
        public void CreateNews_InvalidId_ShouldThrowDomainException()
        {
            // Arrange
            var invalidId = Guid.Empty;
            var status = NewsStatus.Publicada;
            var newsUrl = "https://validurl.com";
            var title = "Valid Title";
            var subtitle = "Valid Subtitle";
            var newsBody = new string('a', 1000);
            var imageUrl = "https://validimage.com";
            var publicationDate = DateTime.UtcNow;
            var author = new UserWithNews(UserRole.Autor, "Valid Author", "author@valid.com", "ValidPassword123", true, null);
            var editor = new UserWithNews(UserRole.Editor, "Valid Editor", "editor@valid.com", "ValidPassword123", true, null);
            var category = new NewsCategory("Valid Category", null, null);
            var subcategories = new List<NewsSubcategory>();

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() => new News(invalidId, status, newsUrl, title, subtitle, newsBody, imageUrl, publicationDate, author, editor, category, subcategories, null));
            Assert.Equal("Id deve ser um GUID válido e não pode ser vazio ou nulo.", exception.Message);
        }

        [Fact]
        public void CreateNews_InvalidTitle_ShouldThrowDomainException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var status = NewsStatus.Publicada;
            var newsUrl = "https://validurl.com";
            var invalidTitle = new string('a', 76);
            var subtitle = "Valid Subtitle";
            var newsBody = new string('a', 1000);
            var imageUrl = "https://validimage.com";
            var publicationDate = DateTime.UtcNow;
            var author = new UserWithNews(UserRole.Autor, "Valid Author", "author@valid.com", "ValidPassword123", true, null);
            var editor = new UserWithNews(UserRole.Editor, "Valid Editor", "editor@valid.com", "ValidPassword123", true, null);
            var category = new NewsCategory("Valid Category", null, null);
            var subcategories = new List<NewsSubcategory>();

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() => new News(id, status, newsUrl, invalidTitle, subtitle, newsBody, imageUrl, publicationDate, author, editor, category, subcategories, null));
            Assert.Equal("O título é obrigatório e não pode exceder 75 caracteres.", exception.Message);
        }

        [Fact]
        public void CreateNews_NullAuthor_ShouldThrowDomainException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var status = NewsStatus.Publicada;
            var newsUrl = "https://validurl.com";
            var title = "Valid Title";
            var subtitle = "Valid Subtitle";
            var newsBody = new string('a', 1000);
            var imageUrl = "https://validimage.com";
            var publicationDate = DateTime.UtcNow;
            UserWithNews? nullAuthor = null;
            var editor = new UserWithNews(UserRole.Editor, "Valid Editor", "editor@valid.com", "ValidPassword123", true, null);
            var category = new NewsCategory("Valid Category", null, null);
            var subcategories = new List<NewsSubcategory>();

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() => new News(id, status, newsUrl, title, subtitle, newsBody, imageUrl, publicationDate, nullAuthor, editor, category, subcategories, null));
            Assert.Equal("O autor da notícia é obrigatório.", exception.Message);
        }

        [Fact]
        public void CreateNews_InvalidUrl_ShouldThrowDomainException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var status = NewsStatus.Publicada;
            var invalidUrl = new string('a', 256);
            var title = "Valid Title";
            var subtitle = "Valid Subtitle";
            var newsBody = new string('a', 1000);
            var imageUrl = "https://validimage.com";
            var publicationDate = DateTime.UtcNow;
            var author = new UserWithNews(UserRole.Autor, "Valid Author", "author@valid.com", "ValidPassword123", true, null);
            var editor = new UserWithNews(UserRole.Editor, "Valid Editor", "editor@valid.com", "ValidPassword123", true, null);
            var category = new NewsCategory("Valid Category", null, null);
            var subcategories = new List<NewsSubcategory>();

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() => new News(id, status, invalidUrl, title, subtitle, newsBody, imageUrl, publicationDate, author, editor, category, subcategories, null));
            Assert.Equal("A URL da notícia é obrigatória e não pode exceder 255 caracteres.", exception.Message);
        }
    }
}
