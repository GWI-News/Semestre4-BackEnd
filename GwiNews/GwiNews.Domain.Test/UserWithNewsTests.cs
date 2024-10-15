using GwiNews.Domain.Entities;
using GwiNews.Domain.Validation;

namespace GwiNews.Domain.Test
{
    public class UserWithNewsTests
    {
        [Fact]
        public void Should_Create_UserWithNews_Successfully()
        {
            // Arrange
            var role = UserRole.Autor;
            var completeName = "John Doe";
            var email = "john.doe@example.com";
            var password = "password123";
            var status = true;
            var news = new List<News>();

            // Act
            var userWithNews = new UserWithNews(role, completeName, email, password, status, news);

            // Assert
            Assert.Equal(role, userWithNews.Role);
            Assert.Equal(completeName, userWithNews.CompleteName);
            Assert.Equal(email, userWithNews.Email);
            Assert.Equal(password, userWithNews.Password);
            Assert.Equal(status, userWithNews.Status);
            Assert.Equal(news, userWithNews.News);
        }

        [Fact]
        public void Should_ThrowException_When_Id_IsInvalid()
        {
            // Arrange
            var role = UserRole.Editor;
            var completeName = "Jane Doe";
            var email = "jane.doe@example.com";
            var password = "password456";
            var status = true;
            var news = new List<News>();

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() =>
                new UserWithNews(Guid.Empty, role, completeName, email, password, status, news)
            );

            Assert.Equal("Id deve ser um GUID válido e não pode ser vazio ou nulo.", exception.Message);
        }

        [Fact]
        public void Should_ThrowException_When_CompleteName_IsNullOrEmpty()
        {
            // Arrange
            var role = UserRole.Leitor;
            var email = "jane.doe@example.com";
            var password = "password456";
            var status = true;
            var news = new List<News>();

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() =>
                new UserWithNews(role, "", email, password, status, news)
            );

            Assert.Equal("O nome completo é obrigatório e não pode exceder 255 caracteres.", exception.Message);
        }

        [Fact]
        public void Should_ThrowException_When_Email_IsInvalid()
        {
            // Arrange
            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() =>
                new UserWithNews(UserRole.Administrador, "Invalid Email User", null, "password789", true, new List<News>())
            );

            Assert.Equal("Um e-mail válido é obrigatório e não pode exceder 255 caracteres.", exception.Message);
        }

        [Fact]
        public void Should_ThrowException_When_Password_IsInvalid()
        {
            // Arrange
            var role = UserRole.Autor;
            var completeName = "John Doe";
            var email = "john.doe@example.com";
            var password = "123";
            var status = true;
            var news = new List<News>();

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() =>
                new UserWithNews(role, completeName, email, password, status, news)
            );

            Assert.Equal("A senha deve ter pelo menos 6 caracteres e não pode exceder 255 caracteres.", exception.Message);
        }

        [Fact]
        public void Should_ActivateUser_Successfully()
        {
            // Arrange
            var role = UserRole.Leitor;
            var completeName = "John Doe";
            var email = "john.doe@example.com";
            var password = "password123";
            var status = false;
            var news = new List<News>();
            var userWithNews = new UserWithNews(role, completeName, email, password, status, news);

            // Act
            userWithNews.ActiveUser(status);

            // Assert
            Assert.True(userWithNews.Status);
        }

        [Fact]
        public void Should_DeactivateUser_Successfully()
        {
            // Arrange
            var role = UserRole.Leitor;
            var completeName = "John Doe";
            var email = "john.doe@example.com";
            var password = "password123";
            var status = true;
            var news = new List<News>();
            var userWithNews = new UserWithNews(role, completeName, email, password, status, news);

            // Act
            userWithNews.ActiveUser(status);

            // Assert
            Assert.False(userWithNews.Status);
        }
    }
}
