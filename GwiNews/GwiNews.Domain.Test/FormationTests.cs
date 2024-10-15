using GwiNews.Domain.Entities;
using GwiNews.Domain.Validation;
using Moq;

namespace GwiNews.Domain.Test
{
    public class FormationTest
    {
        [Fact]
        public void Constructor_WithValidParameters_ShouldCreateFormation()
        {
            // Arrange
            var readerUser = CreateValidReaderUser();
            var id = Guid.NewGuid();
            var name = "Computer Science";
            var institution = "University";
            var startDate = new DateTime(2020, 1, 1);
            var endDate = new DateTime(2024, 1, 1);
            var activity1 = "Activity 1";
            var activity2 = "Activity 2";
            var activity3 = "Activity 3";

            // Act
            var formation = new Formation(id, name, institution, startDate, endDate, activity1, activity2, activity3, readerUser);

            // Assert
            Assert.Equal(id, formation.Id);
            Assert.Equal(name, formation.Name);
            Assert.Equal(institution, formation.Institution);
            Assert.Equal(startDate, formation.StartDate);
            Assert.Equal(endDate, formation.EndDate);
            Assert.Equal(activity1, formation.Activity1);
            Assert.Equal(activity2, formation.Activity2);
            Assert.Equal(activity3, formation.Activity3);
            Assert.Equal(readerUser, formation.ReaderUser);
        }

        [Fact]
        public void Constructor_WithEmptyGuid_ShouldThrowDomainException()
        {
            // Arrange
            var readerUser = CreateValidReaderUser();
            var name = "Computer Science";
            var institution = "University";
            var startDate = new DateTime(2020, 1, 1);
            var endDate = new DateTime(2024, 1, 1);
            var activity1 = "Activity 1";
            var activity2 = "Activity 2";
            var activity3 = "Activity 3";

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() =>
                new Formation(Guid.Empty, name, institution, startDate, endDate, activity1, activity2, activity3, readerUser));

            Assert.Equal("Id deve ser um GUID válido e não pode ser vazio ou nulo.", exception.Message);
        }

        [Fact]
        public void Constructor_WithNullName_ShouldThrowDomainException()
        {
            // Arrange
            var readerUser = CreateValidReaderUser();
            var id = Guid.NewGuid();
            var institution = "University";
            var startDate = new DateTime(2020, 1, 1);
            var endDate = new DateTime(2024, 1, 1);
            var activity1 = "Activity 1";
            var activity2 = "Activity 2";
            var activity3 = "Activity 3";

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() =>
                new Formation(id, null, institution, startDate, endDate, activity1, activity2, activity3, readerUser));

            Assert.Equal("O nome da formação é obrigatório e não pode exceder 255 caracteres.", exception.Message);
        }

        [Fact]
        public void Constructor_WithEndDateBeforeStartDate_ShouldThrowDomainException()
        {
            // Arrange
            var readerUser = CreateValidReaderUser();
            var id = Guid.NewGuid();
            var name = "Computer Science";
            var institution = "University";
            var startDate = new DateTime(2024, 1, 1);
            var endDate = new DateTime(2020, 1, 1);
            var activity1 = "Activity 1";
            var activity2 = "Activity 2";
            var activity3 = "Activity 3";

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() =>
                new Formation(id, name, institution, startDate, endDate, activity1, activity2, activity3, readerUser));

            Assert.Equal("A data de término não pode ser anterior à data de início.", exception.Message);
        }

        [Fact]
        public void Constructor_WithNullReaderUser_ShouldThrowDomainException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Computer Science";
            var institution = "University";
            var startDate = new DateTime(2020, 1, 1);
            var endDate = new DateTime(2024, 1, 1);
            var activity1 = "Activity 1";
            var activity2 = "Activity 2";
            var activity3 = "Activity 3";

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() =>
                new Formation(id, name, institution, startDate, endDate, activity1, activity2, activity3, null));

            Assert.Equal("O Usuário Leitor é obrigatório.", exception.Message);
        }

        private ReaderUser CreateValidReaderUser()
        {
            return new ReaderUser(
                role: UserRole.Leitor,
                completeName: "John Doe",
                email: "john.doe@example.com",
                password: "password123",
                status: true,
                favoritedNews: null,
                professionalInformations: null,
                formations: null,
                professionalSkills: null);
        }
    }
}
