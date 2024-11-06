using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GwiNews.Application.DTOs
{
    public class UserWithNewsDTO : UserDTO
    {
        public UserWithNewsDTO()
        {
            News = new List<NewsDTO>();
        }

        [DisplayName("News")]
        public ICollection<NewsDTO>? News { get; set; }
    }

    public class NewsDTO
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "The Title is required")]
        [StringLength(255, ErrorMessage = "The Title cannot exceed 255 characters")]
        [MinLength(3, ErrorMessage = "The Title must have at least 3 characters")]
        [DisplayName("Title")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "The Content is required")]
        [DisplayName("Content")]
        public string? Content { get; set; }

        [DisplayName("Published Date")]
        public DateTime? PublishedDate { get; set; }

        [DisplayName("Author ID")]
        public Guid? AuthorId { get; set; }
    }
}
