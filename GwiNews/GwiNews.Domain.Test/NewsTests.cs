//using GwiNews.Domain.Entities;
//using GwiNews.Domain.Validation;

//namespace GwiNews.Tests
//{
//    public class NewsTests
//    {
//        [Fact]
//        public void CreateNews_ValidParameters_ShouldCreateNews()
//        {
//            // Arrange
//            var id = Guid.NewGuid();
//            var status = NewsStatus.Publicada;
//            var newsUrl = "https://valid-url.com";
//            var title = "Valid Title";
//            var subtitle = "Valid Subtitle";
//            var newsBody = new string('A', 1000);
//            var imageUrl = "https://image-url.com";
//            var publicationDate = DateTime.Now;
//            var author = new UserWithNews();
//            var editor = new UserWithNews();
//            var newsCategory = new NewsCategory();

//            // Act
//            var news = new News(id, status, newsUrl, title, subtitle, newsBody, imageUrl, publicationDate, author, editor, newsCategory);

//            // Assert
//            Assert.Equal(id, news.Id);
//            Assert.Equal(status, news.Status);
//            Assert.Equal(newsUrl, news.NewsUrl);
//            Assert.Equal(title, news.Title);
//            Assert.Equal(subtitle, news.Subtitle);
//            Assert.Equal(newsBody, news.NewsBody);
//            Assert.Equal(imageUrl, news.ImageUrl);
//            Assert.Equal(publicationDate, news.PublicationDate);
//            Assert.Equal(author, news.Author);
//            Assert.Equal(editor, news.Editor);
//            Assert.Equal(newsCategory, news.NewsCategory);
//        }

//        [Fact]
//        public void CreateNews_InvalidId_ShouldThrowDomainException()
//        {
//            // Arrange
//            var invalidId = Guid.Empty;
//            var status = NewsStatus.Publicada;
//            var newsUrl = "https://valid-url.com";
//            var title = "Valid Title";
//            var subtitle = "Valid Subtitle";
//            var newsBody = new string('A', 1000);
//            var imageUrl = "https://image-url.com";
//            var publicationDate = DateTime.Now;
//            var author = new UserWithNews();
//            var editor = new UserWithNews();
//            var newsCategory = new NewsCategory();

//            // Act & Assert
//            var exception = Assert.Throws<DomainExceptionValidation>(() =>
//                new News(invalidId, status, newsUrl, title, subtitle, newsBody, imageUrl, publicationDate, author, editor, newsCategory)
//            );

//            Assert.Equal("Id deve ser um GUID válido e não pode ser vazio ou nulo.", exception.Message);
//        }

//        [Fact]
//        public void CreateNews_InvalidNewsUrl_ShouldThrowDomainException()
//        {
//            // Arrange
//            var id = Guid.NewGuid();
//            var status = NewsStatus.Publicada;
//            var invalidNewsUrl = new string('A', 256); // URL com mais de 255 caracteres
//            var title = "Valid Title";
//            var subtitle = "Valid Subtitle";
//            var newsBody = new string('A', 1000);
//            var imageUrl = "https://image-url.com";
//            var publicationDate = DateTime.Now;
//            var author = new UserWithNews();
//            var editor = new UserWithNews();
//            var newsCategory = new NewsCategory();

//            // Act & Assert
//            var exception = Assert.Throws<DomainExceptionValidation>(() =>
//                new News(id, status, invalidNewsUrl, title, subtitle, newsBody, imageUrl, publicationDate, author, editor, newsCategory)
//            );

//            Assert.Equal("A URL da notícia é obrigatória e não pode exceder 255 caracteres.", exception.Message);
//        }

//        [Fact]
//        public void CreateNews_InvalidTitle_ShouldThrowDomainException()
//        {
//            // Arrange
//            var id = Guid.NewGuid();
//            var status = NewsStatus.Publicada;
//            var newsUrl = "https://valid-url.com";
//            var invalidTitle = new string('A', 76); // Título com mais de 75 caracteres
//            var subtitle = "Valid Subtitle";
//            var newsBody = new string('A', 1000);
//            var imageUrl = "https://image-url.com";
//            var publicationDate = DateTime.Now;
//            var author = new UserWithNews();
//            var editor = new UserWithNews();
//            var newsCategory = new NewsCategory();

//            // Act & Assert
//            var exception = Assert.Throws<DomainExceptionValidation>(() =>
//                new News(id, status, newsUrl, invalidTitle, subtitle, newsBody, imageUrl, publicationDate, author, editor, newsCategory)
//            );

//            Assert.Equal("O título é obrigatório e não pode exceder 75 caracteres.", exception.Message);
//        }

//        [Fact]
//        public void CreateNews_NullStatus_ShouldThrowDomainException()
//        {
//            // Arrange
//            var id = Guid.NewGuid();
//            NewsStatus? nullStatus = null;
//            var newsUrl = "https://valid-url.com";
//            var title = "Valid Title";
//            var subtitle = "Valid Subtitle";
//            var newsBody = new string('A', 1000);
//            var imageUrl = "https://image-url.com";
//            var publicationDate = DateTime.Now;
//            var author = new UserWithNews();
//            var editor = new UserWithNews();
//            var newsCategory = new NewsCategory();

//            // Act & Assert
//            var exception = Assert.Throws<DomainExceptionValidation>(() =>
//                new News(id, nullStatus, newsUrl, title, subtitle, newsBody, imageUrl, publicationDate, author, editor, newsCategory)
//            );

//            Assert.Equal("O status da notícia é obrigatório.", exception.Message);
//        }

//        [Fact]
//        public void CreateNews_InvalidSubtitle_ShouldThrowDomainException()
//        {
//            // Arrange
//            var id = Guid.NewGuid();
//            var status = NewsStatus.Publicada;
//            var newsUrl = "https://valid-url.com";
//            var title = "Valid Title";
//            var invalidSubtitle = new string('A', 256); // Subtítulo com mais de 255 caracteres
//            var newsBody = new string('A', 1000);
//            var imageUrl = "https://image-url.com";
//            var publicationDate = DateTime.Now;
//            var author = new UserWithNews();
//            var editor = new UserWithNews();
//            var newsCategory = new NewsCategory();

//            // Act & Assert
//            var exception = Assert.Throws<DomainExceptionValidation>(() =>
//                new News(id, status, newsUrl, title, invalidSubtitle, newsBody, imageUrl, publicationDate, author, editor, newsCategory)
//            );

//            Assert.Equal("O subtítulo é obrigatório e não pode exceder 255 caracteres.", exception.Message);
//        }
//    }
//}
