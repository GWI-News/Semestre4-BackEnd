//using GwiNews.Domain.Entities;
//using GwiNews.Domain.Validation;

//namespace GwiNews.Domain.Test
//{
//    public class ProfessionalSkillTest
//    {
//        private ReaderUser GetValidReaderUser()
//        {
//            return new ReaderUser(
//                role: UserRole.Leitor,
//                completeName: "Valid User",
//                email: "valid.email@example.com",
//                password: "validPassword123",
//                status: true,
//                favoritedNews: null,
//                professionalInformations: null,
//                formations: null,
//                professionalSkills: null
//            );
//        }

//        [Fact]
//        public void Instantiate_ValidProfessionalSkill_NoExceptions()
//        {
//            // Arrange
//            var readerUser = GetValidReaderUser();

//            // Act
//            var professionalSkill = new ProfessionalSkill("Skill 1", "Skill 2", "Skill 3", "Skill 4", readerUser);

//            // Assert
//            Assert.NotNull(professionalSkill);
//            Assert.Equal("Skill 1", professionalSkill.Skill1);
//            Assert.Equal("Skill 2", professionalSkill.Skill2);
//            Assert.Equal("Skill 3", professionalSkill.Skill3);
//            Assert.Equal("Skill 4", professionalSkill.Skill4);
//            Assert.Equal(readerUser, professionalSkill.ReaderUser);
//        }

//        [Fact]
//        public void Instantiate_ProfessionalSkill_WithNullOrEmptyId_ShouldThrowDomainException()
//        {
//            // Arrange
//            var readerUser = GetValidReaderUser();
//            var invalidId = Guid.Empty;

//            // Act & Assert
//            var exception = Assert.Throws<DomainExceptionValidation>(() =>
//                new ProfessionalSkill(invalidId, "Skill 1", "Skill 2", "Skill 3", "Skill 4", readerUser));

//            Assert.Equal("Id deve ser um GUID válido e não pode ser vazio ou nulo.", exception.Message);
//        }

//        [Fact]
//        public void Instantiate_ProfessionalSkill_WithInvalidSkillLength_ShouldThrowDomainException()
//        {
//            // Arrange
//            var readerUser = GetValidReaderUser();
//            var longSkill = new string('A', 56);

//            // Act & Assert
//            var exception = Assert.Throws<DomainExceptionValidation>(() =>
//                new ProfessionalSkill(longSkill, "Skill 2", "Skill 3", "Skill 4", readerUser));

//            Assert.Equal("A Habilidade 1 é obrigatória e deve ter no máximo 55 caracteres.", exception.Message);
//        }

//        [Fact]
//        public void Instantiate_ProfessionalSkill_WithNullSkill_ShouldThrowDomainException()
//        {
//            // Arrange
//            var readerUser = GetValidReaderUser();

//            // Act & Assert
//            var exception = Assert.Throws<DomainExceptionValidation>(() =>
//                new ProfessionalSkill(null, "Skill 2", "Skill 3", "Skill 4", readerUser));

//            Assert.Equal("A Habilidade 1 é obrigatória e deve ter no máximo 55 caracteres.", exception.Message);
//        }

//        [Fact]
//        public void Instantiate_ProfessionalSkill_WithNullReaderUser_ShouldThrowDomainException()
//        {
//            // Act & Assert
//            var exception = Assert.Throws<DomainExceptionValidation>(() =>
//                new ProfessionalSkill("Skill 1", "Skill 2", "Skill 3", "Skill 4", null));

//            Assert.Equal("O Usuário Leitor é obrigatório.", exception.Message);
//        }

//        [Fact]
//        public void Instantiate_ProfessionalSkill_WithValidId_ShouldWorkCorrectly()
//        {
//            // Arrange
//            var readerUser = GetValidReaderUser();
//            var validId = Guid.NewGuid();

//            // Act
//            var professionalSkill = new ProfessionalSkill(validId, "Skill 1", "Skill 2", "Skill 3", "Skill 4", readerUser);

//            // Assert
//            Assert.Equal(validId, professionalSkill.Id);
//            Assert.Equal("Skill 1", professionalSkill.Skill1);
//            Assert.Equal("Skill 2", professionalSkill.Skill2);
//            Assert.Equal("Skill 3", professionalSkill.Skill3);
//            Assert.Equal("Skill 4", professionalSkill.Skill4);
//            Assert.Equal(readerUser, professionalSkill.ReaderUser);
//        }
//    }
//}
