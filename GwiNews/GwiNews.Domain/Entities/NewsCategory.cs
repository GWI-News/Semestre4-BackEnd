using GwiNews.Domain.Validation;

namespace GwiNews.Domain.Entities
{
    public class NewsCategory
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        private string _name;
        public string Name
        {
            get => _name;
            private set
            {
                DomainExceptionValidation.When(string.IsNullOrEmpty(value), "O nome da categoria não pode ser vazio.");
                DomainExceptionValidation.When(value.Length > 25, "O nome da categoria não pode exceder 25 caracteres.");
                _name = value;
            }
        }

        public ICollection<News> News { get; private set; } = new List<News>();

        public NewsCategory(string name)
        {
            Name = name; 
        }

        public void UpdateName(string newName)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(newName), "O nome da categoria não pode ser vazio.");
            DomainExceptionValidation.When(newName.Length > 25, "O nome da categoria não pode exceder 25 caracteres.");
            Name = newName;
        }
    }
}
