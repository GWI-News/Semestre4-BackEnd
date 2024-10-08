using GwiNews.Domain.Validation;

namespace GwiNews.Domain.Entities
{
    public class Formation
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Institution { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Activity1 { get; private set; }
        public string Activity2 { get; private set; }
        public string Activity3 { get; private set; }

        // Construtor que aceita 8 argumentos
        public Formation(Guid id, string name, string institution, DateTime startDate, DateTime endDate, string activity1, string activity2, string activity3)
        {
            // Validação do nome
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "O nome da formação é obrigatório.");

            Id = id;
            Name = name;
            Institution = institution;
            StartDate = startDate;
            EndDate = endDate;
            Activity1 = activity1;
            Activity2 = activity2;
            Activity3 = activity3;
        }

        // Construtor sem o Id para criação de novas formações
        public Formation(string name, string institution, DateTime startDate, DateTime endDate, string activity1, string activity2, string activity3)
        {
            // Validação do nome
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "O nome da formação é obrigatório.");

            Id = Guid.NewGuid(); // Gera um novo ID
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
