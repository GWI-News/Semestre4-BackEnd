using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GwiNews.Application.DTOs
{
    public class NewsSubcategoryDTO
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "The Name is required")]
        [StringLength(55, ErrorMessage = "The Name cannot exceed 55 characters")]
        [MinLength(1, ErrorMessage = "The Name must have at least 1 character")]
        [DisplayName("Subcategory Name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The News Category is required")]
        [DisplayName("News Category")]
        public NewsCategoryDTO? NewsCategory { get; set; }

        [DisplayName("Associated News")]
        public ICollection<NewsDTO>? News { get; set; }
    }
}
