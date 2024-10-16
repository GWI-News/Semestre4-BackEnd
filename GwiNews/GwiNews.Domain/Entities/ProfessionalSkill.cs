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
            Skill1 = skill1;
            Skill2 = skill2;
            Skill3 = skill3;
            Skill4 = skill4;
            ReaderUser = readerUser;
        }

        public ProfessionalSkill(Guid? id, string? skill1, string? skill2, string? skill3, string? skill4, ReaderUser? readerUser)
        {
            if (id == null || id == Guid.Empty)
            {
                throw new DomainExceptionValidation("Id deve ser um GUID válido e não pode ser vazio ou nulo.");
            }
            Skill1 = skill1;
            Skill2 = skill2;
            Skill3 = skill3;
            Skill4 = skill4;
            ReaderUser = readerUser;
            Id = id;
        }
    }
}
