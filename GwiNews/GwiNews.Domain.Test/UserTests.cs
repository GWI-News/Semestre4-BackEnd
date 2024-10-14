using GwiNews.Domain.Entities;
using GwiNews.Domain.Validation;

namespace GwiNews.Domain.Test
{
    public class UserTests
    {
        [Fact]
        public void CreateUser_WithValidParameters_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var role = UserRole.Leitor;
            var completeName = "John Doe";
            var email = "john.doe@example.com";
            var password = "StrongPassword123";
            var status = true;

            // Act
            var user = new User(role, completeName, email, password, status);

            // Assert
            Assert.Equal(role, user.Role);
            Assert.Equal(completeName, user.CompleteName);
            Assert.Equal(email, user.Email);
            Assert.Equal(password, user.Password);
            Assert.True(user.Status);
        }

        [Fact]
        public void CreateUser_WithId_ShouldSetIdAndPropertiesCorrectly()
        {
            // Arrange
            var id = Guid.NewGuid();
            var role = UserRole.Autor;
            var completeName = "Jane Smith";
            var email = "jane.smith@example.com";
            var password = "SecurePassword123";
            var status = false;

            // Act
            var user = new User(id, role, completeName, email, password, status);

            // Assert
            Assert.Equal(id, user.Id);
            Assert.Equal(role, user.Role);
            Assert.Equal(completeName, user.CompleteName);
            Assert.Equal(email, user.Email);
            Assert.Equal(password, user.Password);
            Assert.False(user.Status);
        }

        [Fact]
        public void CreateUser_WithInvalidId_ShouldThrowDomainException()
        {
            // Arrange
            var role = UserRole.Administrador;
            var completeName = "Bob Johnson";
            var email = "bob.johnson@example.com";
            var password = "Password123";
            var status = true;

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() =>
                new User(Guid.Empty, role, completeName, email, password, status)
            );

            Assert.Equal("Id deve ser um GUID válido e não pode ser vazio ou nulo.", exception.Message);
        }

        [Fact]
        public void CreateUser_WithNullRole_ShouldThrowDomainException()
        {
            // Arrange
            var completeName = "Alice Brown";
            var email = "alice.brown@example.com";
            var password = "Password123";
            var status = true;

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() =>
                new User(null, completeName, email, password, status)
            );

            Assert.Equal("O papel do usuário é obrigatório.", exception.Message);
        }

        [Fact]
        public void CreateUser_WithInvalidCompleteName_ShouldThrowDomainException()
        {
            // Arrange
            var role = UserRole.Editor;
            var email = "editor@example.com";
            var password = "Password123";
            var status = true;

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() =>
                new User(role, null, email, password, status)
            );

            Assert.Equal("O nome completo é obrigatório e não pode exceder 255 caracteres.", exception.Message);
        }

        [Fact]
        public void CreateUser_WithInvalidEmail_ShouldThrowDomainException()
        {
            // Arrange
            var role = UserRole.Leitor;
            var completeName = "Reader";
            var password = "Password123";
            var status = true;

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() =>
                new User(role, completeName, null, password, status)
            );

            Assert.Equal("Um e-mail válido é obrigatório e não pode exceder 255 caracteres.", exception.Message);
        }

        [Fact]
        public void CreateUser_WithShortPassword_ShouldThrowDomainException()
        {
            // Arrange
            var role = UserRole.Autor;
            var completeName = "Author";
            var email = "author@example.com";
            var password = "12345";
            var status = true;

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() =>
                new User(role, completeName, email, password, status)
            );

            Assert.Equal("A senha deve ter pelo menos 6 caracteres e não pode exceder 255 caracteres.", exception.Message);
        }

        [Fact]
        public void ActiveUser_WithInactiveStatus_ShouldActivateUser()
        {
            // Arrange
            var role = UserRole.Editor;
            var completeName = "Inactive User";
            var email = "inactive@example.com";
            var password = "Password123";
            var status = false;

            var user = new User(role, completeName, email, password, status);

            // Act
            user.ActiveUser(status);

            // Assert
            Assert.True(user.Status);
        }

        [Fact]
        public void ActiveUser_WithActiveStatus_ShouldDeactivateUser()
        {
            // Arrange
            var role = UserRole.Administrador;
            var completeName = "Active User";
            var email = "active@example.com";
            var password = "Password123";
            var status = true;

            var user = new User(role, completeName, email, password, status);

            // Act
            user.ActiveUser(status);

            // Assert
            Assert.False(user.Status);
        }
    }
}
