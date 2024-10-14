//using GwiNews.Domain.Entities;
//using GwiNews.Domain.Validation;

//namespace GwiNews.Domain.Test
//{
//    public class ProfessionalInformationTest
//    {
//        [Fact]
//        public void Constructor_ShouldInitializeWithValidParameters()
//        {
//            // Arrange
//            var completeName = "John Doe";
//            var telefone = "+1234567890";
//            var email = "johndoe@example.com";
//            var linkedin = "https://linkedin.com/in/johndoe";
//            var enderecoCompleto = "123 Main St, Anytown, USA";
//            var objetivo = "To obtain a challenging position.";
//            var imgUrl = "https://example.com/image.jpg";

//            // Act
//            var professionalInfo = new ProfessionalInformation(completeName, telefone, email, linkedin, enderecoCompleto, objetivo, imgUrl);

//            // Assert
//            Assert.NotNull(professionalInfo);
//            Assert.Equal(completeName, professionalInfo.CompleteName);
//            Assert.Equal(telefone, professionalInfo.Telefone);
//            Assert.Equal(email, professionalInfo.Email);
//            Assert.Equal(linkedin, professionalInfo.Linkedin);
//            Assert.Equal(enderecoCompleto, professionalInfo.EnderecoCompleto);
//            Assert.Equal(objetivo, professionalInfo.Objetivo);
//            Assert.Equal(imgUrl, professionalInfo.ImgUrl);
//        }

//        [Fact]
//        public void Constructor_ShouldThrowException_WhenCompleteNameIsEmpty()
//        {
//            // Act & Assert
//            var exception = Assert.Throws<DomainExceptionValidation>(() =>
//                new ProfessionalInformation(string.Empty, "+1234567890", "johndoe@example.com", "https://linkedin.com/in/johndoe", "123 Main St", "To obtain a challenging position.", "https://example.com/image.jpg")
//            );
//            Assert.Equal("O nome completo é obrigatório.", exception.Message);
//        }

//        [Fact]
//        public void Constructor_ShouldThrowException_WhenEmailIsInvalid()
//        {
//            // Act & Assert
//            var exception = Assert.Throws<DomainExceptionValidation>(() =>
//                new ProfessionalInformation("John Doe", "+1234567890", "invalid_email", "https://linkedin.com/in/johndoe", "123 Main St", "To obtain a challenging position.", "https://example.com/image.jpg")
//            );
//            Assert.Equal("O email fornecido não é válido.", exception.Message);
//        }

//        [Fact]
//        public void Update_ShouldUpdateProfessionalInformation()
//        {
//            // Arrange
//            var completeName = "John Doe";
//            var telefone = "+1234567890";
//            var email = "johndoe@example.com";
//            var linkedin = "https://linkedin.com/in/johndoe";
//            var enderecoCompleto = "123 Main St, Anytown, USA";
//            var objetivo = "To obtain a challenging position.";
//            var imgUrl = "https://example.com/image.jpg";

//            var professionalInfo = new ProfessionalInformation(completeName, telefone, email, linkedin, enderecoCompleto, objetivo, imgUrl);

//            // New values for update
//            var newCompleteName = "Jane Doe";
//            var newTelefone = "+0987654321";
//            var newEmail = "janedoe@example.com";
//            var newLinkedin = "https://linkedin.com/in/janedoe";
//            var newEnderecoCompleto = "456 Elm St, Othertown, USA";
//            var newObjetivo = "To excel in my career.";
//            var newImgUrl = "https://example.com/newimage.jpg";

//            // Act
//            professionalInfo.Update(professionalInfo.Id, newCompleteName, newTelefone, newEmail, newLinkedin, newEnderecoCompleto, newObjetivo, newImgUrl);

//            // Assert
//            Assert.Equal(newCompleteName, professionalInfo.CompleteName);
//            Assert.Equal(newTelefone, professionalInfo.Telefone);
//            Assert.Equal(newEmail, professionalInfo.Email);
//            Assert.Equal(newLinkedin, professionalInfo.Linkedin);
//            Assert.Equal(newEnderecoCompleto, professionalInfo.EnderecoCompleto);
//            Assert.Equal(newObjetivo, professionalInfo.Objetivo);
//            Assert.Equal(newImgUrl, professionalInfo.ImgUrl);
//        }
//    }
//}
