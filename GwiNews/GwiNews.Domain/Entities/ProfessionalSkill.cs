using GwiNews.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace GwiNews.Domain.Entities
{
    public class ProfessionalSkill
    {
        [Key]
        public Guid? Id { get; private set; }
        [Required]
        [StringLength(55)]
        public string? Skill1 { get; private set; }
        [Required]
        [StringLength(55)]
        public string? Skill2 { get; private set; }
        [Required]
        [StringLength(55)]
        public string? Skill3 { get; private set; }
        [Required]
        [StringLength(55)]
        public string? Skill4 { get; private set; }
        [Required]
        public ReaderUser? ReaderUser { get; private set; }

        public ProfessionalSkill(string? skill1, string? skill2, string? skill3, string? skill4, ReaderUser? readerUser)
        {
            ValidationDomain(skill1, skill2, skill3, skill4, readerUser);
        }

        public ProfessionalSkill(Guid? id, string? skill1, string? skill2, string? skill3, string? skill4, ReaderUser? readerUser)
        {
            if (id == null || id == Guid.Empty)
            {
                throw new DomainExceptionValidation("Id deve ser um GUID válido e não pode ser vazio ou nulo.");
            }
            ValidationDomain(skill1, skill2, skill3, skill4, readerUser);
            Id = id;
        }

        private void ValidationDomain(string? skill1, string? skill2, string? skill3, string? skill4, ReaderUser? readerUser)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(skill1) || skill1.Length > 55, "A Habilidade 1 é obrigatória e deve ter no máximo 55 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(skill2) || skill2.Length > 55, "A Habilidade 2 é obrigatória e deve ter no máximo 55 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(skill3) || skill3.Length > 55, "A Habilidade 3 é obrigatória e deve ter no máximo 55 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(skill4) || skill4.Length > 55, "A Habilidade 4 é obrigatória e deve ter no máximo 55 caracteres.");
            DomainExceptionValidation.When(readerUser == null, "O Usuário Leitor é obrigatório.");

            Skill1 = skill1;
            Skill2 = skill2;
            Skill3 = skill3;
            Skill4 = skill4;
            ReaderUser = readerUser;
        }
    }
}
