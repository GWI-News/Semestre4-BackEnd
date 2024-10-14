using GwiNews.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace GwiNews.Domain.Entities
{
    public class ProfessionalInformation
    {
        [Key]
        public Guid? Id { get; private set; }
        [Required]
        [StringLength(255)]
        public string? CompleteName { get; private set; }
        [Required]
        [Phone]
        public string? PhoneNumber { get; private set; }
        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string? Email { get; private set; }
        [Required]
        [StringLength(255)]
        public string? Linkedin { get; private set; }
        [Required]
        [StringLength(510)]
        public string? CompleteAddress { get; private set; }
        [Required]
        [StringLength(255)]
        public string? Purpose { get; private set; }
        [Required]
        [Url]
        [StringLength(555)]
        public string? ImgUrl { get; private set; }
        public ReaderUser? ReaderUser { get; private set; }

        public ProfessionalInformation(string? completeName, string? phoneNumber, string? email, string? linkedin, string? completeAddress, string? purpose, string? imgUrl, ReaderUser? readerUser)
        {
            ValidationDomain(completeName, phoneNumber, email, linkedin, completeAddress, purpose, imgUrl, readerUser);
        }

        public ProfessionalInformation(Guid? id, string? completeName, string? phoneNumber, string? email, string? linkedin, string? completeAddress, string? purpose, string? imgUrl, ReaderUser? readerUser)
        {
            if (id == null || id == Guid.Empty)
            {
                throw new DomainExceptionValidation("Id deve ser um GUID válido e não pode ser vazio ou nulo.");
            }
            ValidationDomain(completeName, phoneNumber, email, linkedin, completeAddress, purpose, imgUrl, readerUser);
            Id = id;
        }

        private void ValidationDomain(string? completeName, string? phoneNumber, string? email, string? linkedin, string? completeAddress, string? purpose, string? imgUrl, ReaderUser? readerUser)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(completeName) || completeName.Length > 255, "O nome completo é obrigatório e não pode exceder 255 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length > 16, "Um número de telefone válido é obrigatório e não pode exceder 16 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(email) || email.Length > 255, "Um e-mail válido é obrigatório e não pode exceder 255 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(linkedin) || linkedin.Length > 255, "O LinkedIn é obrigatório e não pode exceder 255 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(completeAddress) || completeAddress.Length > 510, "O endereço completo é obrigatório e não pode exceder 510 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(purpose) || purpose.Length > 255, "O objetivo é obrigatório e não pode exceder 255 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(imgUrl) || imgUrl.Length > 555, "A URL da imagem é obrigatória e não pode exceder 555 caracteres.");
            DomainExceptionValidation.When(readerUser == null, "O Usuário Leitor é obrigatório.");

            CompleteName = completeName;
            PhoneNumber = phoneNumber;
            Email = email;
            Linkedin = linkedin;
            CompleteAddress = completeAddress;
            Purpose = purpose;
            ImgUrl = imgUrl;
            ReaderUser = readerUser;
        }
    }
}