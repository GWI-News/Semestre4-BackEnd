using GwiNews.Domain.Entities;
using GwiNews.Domain.Validation;

namespace GwiNews.Domain.Test
{
    public class ProfessionalInformationTest
    {
        [Fact]
        public void Constructor_WithValidParameters_ShouldCreateProfessionalInformation()
        {
            // Arrange
            var readerUser = CreateReaderUser();

            // Act
            var professionalInformation = new ProfessionalInformation(
                "John Doe",
                "123456789",
                "john.doe@example.com",
                "linkedin.com/in/johndoe",
                "123 Main St, City, Country",
                "Seeking new opportunities",
                "http://example.com/img.jpg",
                readerUser
            );

            // Assert
            Assert.NotNull(professionalInformation);
            Assert.Equal("John Doe", professionalInformation.CompleteName);
            Assert.Equal("123456789", professionalInformation.PhoneNumber);
            Assert.Equal("john.doe@example.com", professionalInformation.Email);
            Assert.Equal("linkedin.com/in/johndoe", professionalInformation.Linkedin);
            Assert.Equal("123 Main St, City, Country", professionalInformation.CompleteAddress);
            Assert.Equal("Seeking new opportunities", professionalInformation.Purpose);
            Assert.Equal("http://example.com/img.jpg", professionalInformation.ImgUrl);
            Assert.Equal(readerUser, professionalInformation.ReaderUser);
        }

        [Fact]
        public void Constructor_WithNullId_ShouldThrowDomainException()
        {
            // Arrange
            var readerUser = CreateReaderUser();

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() => new ProfessionalInformation(
                Guid.Empty,
                "John Doe",
                "123456789",
                "john.doe@example.com",
                "linkedin.com/in/johndoe",
                "123 Main St, City, Country",
                "Seeking new opportunities",
                "http://example.com/img.jpg",
                readerUser
            ));

            Assert.Equal("Id deve ser um GUID válido e não pode ser vazio ou nulo.", exception.Message);
        }

        [Fact]
        public void Constructor_WithInvalidCompleteName_ShouldThrowDomainException()
        {
            // Arrange
            var readerUser = CreateReaderUser();

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() => new ProfessionalInformation(
                "",
                "123456789",
                "john.doe@example.com",
                "linkedin.com/in/johndoe",
                "123 Main St, City, Country",
                "Seeking new opportunities",
                "http://example.com/img.jpg",
                readerUser
            ));

            Assert.Equal("O nome completo é obrigatório e não pode exceder 255 caracteres.", exception.Message);
        }

        [Fact]
        public void Constructor_WithInvalidEmail_ShouldThrowDomainException()
        {
            // Arrange
            var readerUser = CreateReaderUser();

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() => new ProfessionalInformation(
                "John Doe",
                "123456789",
                new string('e', 256),
                "linkedin.com/in/johndoe",
                "123 Main St, City, Country",
                "Seeking new opportunities",
                "http://example.com/img.jpg",
                readerUser
            ));

            Assert.Equal("Um e-mail válido é obrigatório e não pode exceder 255 caracteres.", exception.Message);
        }

        [Fact]
        public void Constructor_WithNullReaderUser_ShouldThrowDomainException()
        {
            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() => new ProfessionalInformation(
                "John Doe",
                "123456789",
                "john.doe@example.com",
                "linkedin.com/in/johndoe",
                "123 Main St, City, Country",
                "Seeking new opportunities",
                "http://example.com/img.jpg",
                null
            ));

            Assert.Equal("O Usuário Leitor é obrigatório.", exception.Message);
        }

        private ReaderUser CreateReaderUser()
        {
            return new ReaderUser(
                new UserRole(),
                "Jane Doe",
                "jane.doe@example.com",
                "password123",
                true,
                null,
                null,
                null,
                null
            );
        }
    }
}
