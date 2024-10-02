using GwiNews.Domain.Entities;
using GwiNews.Domain.Validation;

namespace GwiNews.Domain.Test
{
    public class UserTests
    {
        [Fact]
        public void Constructor_WithValidParameters_ShouldCreateUserWithoutId()
        {
            var user = new User(UserRole.Administrador, "Nome Completo", "email@example.com", "senha123", true);

            Assert.NotNull(user);
            Assert.Null(user.Id);
            Assert.Equal(UserRole.Administrador, user.Role);
            Assert.Equal("Nome Completo", user.CompleteName);
            Assert.Equal("email@example.com", user.Email);
            Assert.Equal("senha123", user.Password);
            Assert.True(user.Status);
        }

        [Fact]
        public void Constructor_WithValidParameters_ShouldCreateUserWithId()
        {
            var userId = Guid.NewGuid();
            var user = new User(userId, UserRole.Administrador, "Nome Completo", "email@example.com", "senha123", true);

            Assert.NotNull(user);
            Assert.Equal(userId, user.Id);
            Assert.Equal(UserRole.Administrador, user.Role);
            Assert.Equal("Nome Completo", user.CompleteName);
            Assert.Equal("email@example.com", user.Email);
            Assert.Equal("senha123", user.Password);
            Assert.True(user.Status);
        }

        [Fact]
        public void Constructor_WithEmptyGuid_ShouldThrowDomainException()
        {
            Assert.Throws<DomainExceptionValidation>(() => new User(Guid.Empty, UserRole.Administrador, "Nome Completo", "email@example.com", "senha123", true));
        }

        [Fact]
        public void Constructor_WithNullRole_ShouldThrowDomainException()
        {
            Assert.Throws<DomainExceptionValidation>(() => new User(Guid.NewGuid(), null, "Nome Completo", "email@example.com", "senha123", true));
        }

        [Fact]
        public void Constructor_WithInvalidCompleteName_ShouldThrowDomainException()
        {
            Assert.Throws<DomainExceptionValidation>(() => new User(Guid.NewGuid(), UserRole.Administrador, new string('A', 256), "email@example.com", "senha123", true));
        }

        [Fact]
        public void Constructor_WithInvalidEmail_ShouldThrowDomainException()
        {
            Assert.Throws<DomainExceptionValidation>(() => new User(Guid.NewGuid(), UserRole.Administrador, "Nome Completo", new string('A', 256), "senha123", true));
        }

        [Fact]
        public void Constructor_WithInvalidPassword_ShouldThrowDomainException()
        {
            Assert.Throws<DomainExceptionValidation>(() => new User(Guid.NewGuid(), UserRole.Administrador, "Nome Completo", "email@example.com", new string('A', 256), true));
        }

        [Fact]
        public void Constructor_WithShortPassword_ShouldThrowDomainException()
        {
            Assert.Throws<DomainExceptionValidation>(() => new User(Guid.NewGuid(), UserRole.Administrador, "Nome Completo", "email@example.com", "123", true));
        }

        [Fact]
        public void Constructor_WithNullStatus_ShouldThrowDomainException()
        {
            Assert.Throws<DomainExceptionValidation>(() => new User(Guid.NewGuid(), UserRole.Administrador, "Nome Completo", "email@example.com", "senha123", null));
        }
    }
}
