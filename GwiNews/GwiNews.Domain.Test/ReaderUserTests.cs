using GwiNews.Domain.Entities;
using GwiNews.Domain.Validation;

namespace GwiNews.Domain.Test
{
    public class ReaderUserTests
    {
        [Fact]
        public void ShouldCreateReaderUserWithValidParameters()
        {
            // Arrange
            var favoritedNews = new List<News>();
            var professionalInformations = new List<ProfessionalInformation>();
            var formations = new List<Formation>();
            var professionalSkills = new List<ProfessionalSkill>();

            var readerUser = new ReaderUser(
                UserRole.Leitor,
                "John Doe",
                "john.doe@example.com",
                "securePassword123",
                true,
                favoritedNews,
                professionalInformations,
                formations,
                professionalSkills
            );

            // Assert
            Assert.NotNull(readerUser);
            Assert.Equal(UserRole.Leitor, readerUser.Role);
            Assert.Equal("John Doe", readerUser.CompleteName);
            Assert.Equal("john.doe@example.com", readerUser.Email);
            Assert.Equal("securePassword123", readerUser.Password);
            Assert.True(readerUser.Status);
            Assert.Equal(favoritedNews, readerUser.FavoritedNews);
            Assert.Equal(professionalInformations, readerUser.ProfessionalInformations);
            Assert.Equal(formations, readerUser.Formations);
            Assert.Equal(professionalSkills, readerUser.ProfessionalSkills);
        }

        [Fact]
        public void ShouldThrowExceptionWhenEmailIsInvalid()
        {
            // Arrange & Act
            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                new ReaderUser(
                    UserRole.Leitor,
                    "John Doe",
                    null,
                    "securePassword123",
                    true,
                    null,
                    null,
                    null,
                    null
                )
            );

            // Assert
            Assert.Equal("Um e-mail válido é obrigatório e não pode exceder 255 caracteres.", ex.Message);
        }

        [Fact]
        public void ShouldThrowExceptionWhenPasswordIsTooShort()
        {
            // Arrange & Act
            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                new ReaderUser(
                    UserRole.Leitor,
                    "John Doe",
                    "john.doe@example.com",
                    "123",
                    true,
                    null,
                    null,
                    null,
                    null
                )
            );

            // Assert
            Assert.Equal("A senha deve ter pelo menos 6 caracteres e não pode exceder 255 caracteres.", ex.Message);
        }

        [Fact]
        public void ShouldThrowExceptionWhenRoleIsNull()
        {
            // Arrange & Act
            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                new ReaderUser(
                    null, // Role is null
                    "John Doe",
                    "john.doe@example.com",
                    "securePassword123",
                    true,
                    null,
                    null,
                    null,
                    null
                )
            );

            // Assert
            Assert.Equal("O papel do usuário é obrigatório.", ex.Message);
        }

        [Fact]
        public void ShouldCreateReaderUserWithNullCollections()
        {
            // Arrange & Act
            var readerUser = new ReaderUser(
                UserRole.Leitor,
                "John Doe",
                "john.doe@example.com",
                "securePassword123",
                true,
                null,
                null,
                null,
                null 
            );

            // Assert
            Assert.NotNull(readerUser);
            Assert.Null(readerUser.FavoritedNews);
            Assert.Null(readerUser.ProfessionalInformations);
            Assert.Null(readerUser.Formations);
            Assert.Null(readerUser.ProfessionalSkills);
        }

        [Fact]
        public void ShouldCreateReaderUserWithValidId()
        {
            // Arrange
            var validId = Guid.NewGuid();
            var readerUser = new ReaderUser(
                validId,
                UserRole.Leitor,
                "John Doe",
                "john.doe@example.com",
                "securePassword123",
                true,
                null,
                null,
                null,
                null
            );

            // Assert
            Assert.NotNull(readerUser);
            Assert.Equal(validId, readerUser.Id);
        }

        [Fact]
        public void ShouldThrowExceptionForInvalidId()
        {
            // Arrange & Act
            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                new ReaderUser(
                    Guid.Empty,
                    UserRole.Leitor,
                    "John Doe",
                    "john.doe@example.com",
                    "securePassword123",
                    true,
                    null,
                    null,
                    null,
                    null
                )
            );

            // Assert
            Assert.Equal("Id deve ser um GUID válido e não pode ser vazio ou nulo.", ex.Message);
        }
    }
}
