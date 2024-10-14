//using GwiNews.Domain.Entities;
//using GwiNews.Domain.Validation;

//namespace GwiNews.Domain.Test
//{
//    public class ProfessionalSkillTest
//    {
//        [Fact]
//        public void Constructor_ShouldInitializeWithValidParameters()
//        {
//            // Arrange
//            var skill1 = "C# Programming";
//            var skill2 = "SQL Database";
//            var skill3 = "Web Development";
//            var skill4 = "Machine Learning";

//            // Act
//            var professionalSkill = new ProfessionalSkill(skill1, skill2, skill3, skill4);

//            // Assert
//            Assert.NotNull(professionalSkill);
//            Assert.Equal(skill1, professionalSkill.Skill1);
//            Assert.Equal(skill2, professionalSkill.Skill2);
//            Assert.Equal(skill3, professionalSkill.Skill3);
//            Assert.Equal(skill4, professionalSkill.Skill4);
//        }

//        [Fact]
//        public void Constructor_ShouldThrowException_WhenSkill1IsEmpty()
//        {
//            // Act & Assert
//            var exception = Assert.Throws<DomainExceptionValidation>(() =>
//                new ProfessionalSkill(string.Empty, "Skill 2", "Skill 3", "Skill 4")
//            );
//            Assert.Equal("A Skill1 é obrigatória.", exception.Message);
//        }

//        [Fact]
//        public void Constructor_ShouldThrowException_WhenSkill1ExceedsMaxLength()
//        {
//            // Arrange
//            var longSkill = new string('a', 56); // 56 characters long

//            // Act & Assert
//            var exception = Assert.Throws<DomainExceptionValidation>(() =>
//                new ProfessionalSkill(longSkill, "Skill 2", "Skill 3", "Skill 4")
//            );
//            Assert.Equal("A Skill1 não pode exceder 55 caracteres.", exception.Message);
//        }

//        [Fact]
//        public void Update_ShouldUpdateProfessionalSkill()
//        {
//            // Arrange
//            var skill1 = "C# Programming";
//            var skill2 = "SQL Database";
//            var skill3 = "Web Development";
//            var skill4 = "Machine Learning";

//            var professionalSkill = new ProfessionalSkill(skill1, skill2, skill3, skill4);

//            // New values for update
//            var newSkill1 = "Python Programming";
//            var newSkill2 = "Data Analysis";
//            var newSkill3 = "Cloud Computing";
//            var newSkill4 = "AI Development";

//            // Act
//            professionalSkill.Update(professionalSkill.Id, newSkill1, newSkill2, newSkill3, newSkill4);

//            // Assert
//            Assert.Equal(newSkill1, professionalSkill.Skill1);
//            Assert.Equal(newSkill2, professionalSkill.Skill2);
//            Assert.Equal(newSkill3, professionalSkill.Skill3);
//            Assert.Equal(newSkill4, professionalSkill.Skill4);
//        }
//    }
//}
