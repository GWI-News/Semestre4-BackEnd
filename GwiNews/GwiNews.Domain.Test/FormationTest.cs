using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Domain.Validation;
using Moq;

namespace GwiNews.Domain.Test
{
    public class FormationTest
    {
        private readonly Mock<IFormationRepository> _formationRepositoryMock;

        public FormationTest()
        {
            _formationRepositoryMock = new Mock<IFormationRepository>();
        }

        [Fact]
        public void Constructor_ShouldInitializeWithValidParameters()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Bachelor of Science in Computer Science";
            var institution = "XYZ University";
            var startDate = new DateTime(2015, 9, 1);
            var endDate = new DateTime(2019, 6, 30);
            var activity1 = "Developed AI-based applications";
            var activity2 = "Contributed to open-source projects";
            var activity3 = "Participated in programming competitions";

            // Act
            var formation = new Formation(id, name, institution, startDate, endDate, activity1, activity2, activity3);

            // Assert
            Assert.Equal(id, formation.Id);
            Assert.Equal(name, formation.Name);
            Assert.Equal(institution, formation.Institution);
            Assert.Equal(startDate, formation.StartDate);
            Assert.Equal(endDate, formation.EndDate);
            Assert.Equal(activity1, formation.Activity1);
            Assert.Equal(activity2, formation.Activity2);
            Assert.Equal(activity3, formation.Activity3);
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenNameIsEmpty()
        {
            // Arrange
            var id = Guid.NewGuid();
            var institution = "XYZ University";
            var startDate = new DateTime(2015, 9, 1);
            var endDate = new DateTime(2019, 6, 30);
            var activity1 = "Developed AI-based applications";
            var activity2 = "Contributed to open-source projects";
            var activity3 = "Participated in programming competitions";

            // Act & Assert
            var exception = Assert.Throws<DomainExceptionValidation>(() =>
                new Formation(id, string.Empty, institution, startDate, endDate, activity1, activity2, activity3)
            );
            Assert.Equal("O nome da formação é obrigatório.", exception.Message);
        }

        [Fact]
        public async Task GetAllFormationsAsync_ShouldReturnAllFormations()
        {
            // Arrange
            var mockFormations = new List<Formation>
    {
        new Formation(Guid.NewGuid(), "Formation 1", "Institution 1", DateTime.Now.AddYears(-4), DateTime.Now, "Activity 1", "Activity 2", "Activity 3"),
        new Formation(Guid.NewGuid(), "Formation 2", "Institution 2", DateTime.Now.AddYears(-6), DateTime.Now.AddYears(-1), "Activity 1", "Activity 2", "Activity 3")
    };

            // Aqui garantimos que o mock retorna a lista como IEnumerable<Formation>
            _formationRepositoryMock
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(mockFormations.AsEnumerable());  // Retorna como IEnumerable<Formation>

            // Act
            var result = await _formationRepositoryMock.Object.GetAllAsync();

            // Assert
            Assert.NotNull(result);  // Verifica que o resultado não é nulo
            Assert.Equal(2, result.Count());  // Usa Count() em vez de Count
        }


        [Fact]
        public async Task GetFormationByIdAsync_ShouldReturnCorrectFormation()
        {
            // Arrange
            var formationId = Guid.NewGuid();
            var mockFormation = new Formation(formationId, "Formation 1", "Institution 1", DateTime.Now.AddYears(-4), DateTime.Now, "Activity 1", "Activity 2", "Activity 3");

            _formationRepositoryMock.Setup(repo => repo.GetByIdAsync(formationId)).ReturnsAsync(mockFormation);

            // Act
            var result = await _formationRepositoryMock.Object.GetByIdAsync(formationId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(formationId, result.Id);
            Assert.Equal("Formation 1", result.Name);
        }

        [Fact]
        public async Task CreateFormationAsync_ShouldReturnNewlyCreatedFormation()
        {
            // Arrange
            var newFormation = new Formation("Formation 1", "Institution 1", DateTime.Now.AddYears(-4), DateTime.Now, "Activity 1", "Activity 2", "Activity 3");

            _formationRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<Formation>())).ReturnsAsync(newFormation);

            // Act
            var result = await _formationRepositoryMock.Object.CreateAsync(newFormation);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Formation 1", result.Name);
        }
        [Fact]
        public async Task UpdateFormationAsync_ShouldUpdateAndReturnUpdatedFormation()
        {
            // Arrange
            var existingFormation = new Formation(Guid.NewGuid(), "Old Formation", "Old Institution", DateTime.Now.AddYears(-6), DateTime.Now.AddYears(-1), "Old Activity 1", "Old Activity 2", "Old Activity 3");

            _formationRepositoryMock.Setup(repo => repo.GetByIdAsync(existingFormation.Id)).ReturnsAsync(existingFormation);

            // Simula a atualização retornando a formação com os novos valores
            var updatedFormation = new Formation(existingFormation.Id, "Updated Formation", "Updated Institution", DateTime.Now.AddYears(-5), DateTime.Now, "Updated Activity 1", "Updated Activity 2", "Updated Activity 3");

            _formationRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Formation>())).ReturnsAsync(updatedFormation);

            // Act
            var result = await _formationRepositoryMock.Object.UpdateAsync(updatedFormation);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Updated Formation", result.Name);
        }



        [Fact]
        public async Task DeleteFormationAsync_ShouldDeleteFormation()
        {
            // Arrange
            var formationId = Guid.NewGuid();
            var mockFormation = new Formation(formationId, "Formation 1", "Institution 1", DateTime.Now.AddYears(-4), DateTime.Now, "Activity 1", "Activity 2", "Activity 3");

            _formationRepositoryMock.Setup(repo => repo.GetByIdAsync(formationId)).ReturnsAsync(mockFormation);
            _formationRepositoryMock.Setup(repo => repo.DeleteAsync(formationId)).Returns(Task.CompletedTask);

            // Act
            await _formationRepositoryMock.Object.DeleteAsync(formationId);

            // Assert
            _formationRepositoryMock.Verify(repo => repo.DeleteAsync(formationId), Times.Once);
        }
    }
}
