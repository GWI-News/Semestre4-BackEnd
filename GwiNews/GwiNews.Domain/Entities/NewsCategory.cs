namespace GwiNews.Domain.Entities
{
    public class NewsCategory
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (value.Length > 25)
                {
                    throw new ArgumentException("O nome da categoria não pode exceder 25 caracteres.");
                }
                _name = value;
            }
        }

        public ICollection<News> News { get; set; } = new List<News>();

        //public ICollection<NewsSubcategory> NewsSubcategories { get; set; } = new List<NewsSubcategory>();

        public NewsCategory(string name)
        {
            Name = name;
        }
    }
}
