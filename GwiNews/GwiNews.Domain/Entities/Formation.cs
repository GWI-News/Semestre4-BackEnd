using GwiNews.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace GwiNews.Domain.Entities
{
    public class Formation
    {
        [Key]
        public Guid? Id { get; private set; }
        [Required]
        public string? Name { get; private set; }
        [Required]
        public string? Institution { get; private set; }
        [Required]
        public DateTime? StartDate { get; private set; }
        [Required]
        public DateTime? EndDate { get; private set; }
        [Required]
        public string? Activity1 { get; private set; }
        [Required]
        public string? Activity2 { get; private set; }
        [Required]
        public string? Activity3 { get; private set; }
        //[Required]
        //public ReaderUser? ReaderUser { get; private set; }

        public Formation(Guid? id, string? name, string? institution, DateTime? startDate, DateTime? endDate, string? activity1, string? activity2, string? activity3)
        {
            if (id == null || id == Guid.Empty)
            {
                throw new DomainExceptionValidation("Id deve ser um GUID válido e não pode ser vazio ou nulo.");
            }
            ValidateDomain(name, institution, startDate, endDate, activity1, activity2, activity3);
            Id = id;
        }

        public Formation(string? name, string? institution, DateTime? startDate, DateTime? endDate, string? activity1, string? activity2, string? activity3)
        {
            ValidateDomain(name, institution, startDate, endDate, activity1, activity2, activity3);
        }

        private void ValidateDomain(string? name, string? institution, DateTime? startDate, DateTime? endDate, string? activity1, string? activity2, string? activity3)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name) || name.Length > 255, "O nome da formação é obrigatório e não pode exceder 255 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(institution) || institution.Length > 255, "A instituição é obrigatória e não pode exceder 255 caracteres.");
            DomainExceptionValidation.When(startDate == null, "A data de início é obrigatória.");
            DomainExceptionValidation.When(endDate == null, "A data de término é obrigatória.");
            DomainExceptionValidation.When(endDate < startDate, "A data de término não pode ser anterior à data de início.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(activity1) || activity1.Length > 255, "A atividade 1 é obrigatória e não pode exceder 255 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(activity2) || activity2.Length > 255, "A atividade 2 é obrigatória e não pode exceder 255 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(activity3) || activity3.Length > 255, "A atividade 3 é obrigatória e não pode exceder 255 caracteres.");

            Name = name;
            Institution = institution;
            StartDate = startDate;
            EndDate = endDate;
            Activity1 = activity1;
            Activity2 = activity2;
            Activity3 = activity3;
        }
    }
}
