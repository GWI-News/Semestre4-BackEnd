using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GwiNews.Domain.Entities;

namespace GwiNews.Application.DTOs
{
    public class NewsDTO
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "The Status is required")]
        [DisplayName("News Status")]
        public NewsStatus? Status { get; set; }

        [Required(ErrorMessage = "The News URL is required")]
        [StringLength(255, ErrorMessage = "The News URL cannot exceed 255 characters")]
        [DisplayName("News URL")]
        public string? NewsUrl { get; set; }

        [Required(ErrorMessage = "The Title is required")]
        [StringLength(75, ErrorMessage = "The Title cannot exceed 75 characters")]
        [DisplayName("Title")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "The Subtitle is required")]
        [StringLength(255, ErrorMessage = "The Subtitle cannot exceed 255 characters")]
        [DisplayName("Subtitle")]
        public string? Subtitle { get; set; }

        [Required(ErrorMessage = "The News Body is required")]
        [StringLength(65535, ErrorMessage = "The News Body cannot exceed 65,535 characters")]
        [DisplayName("News Body")]
        public string? NewsBody { get; set; }

        [Required(ErrorMessage = "The Image URL is required")]
        [StringLength(555, ErrorMessage = "The Image URL cannot exceed 555 characters")]
        [DisplayName("Image URL")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "The Publication Date is required")]
        [DisplayName("Publication Date")]
        public DateTime? PublicationDate { get; set; }

        [Required(ErrorMessage = "The Author is required")]
        [DisplayName("Author")]
        public UserDTO? Author { get; set; }

        [Required(ErrorMessage = "The Editor is required")]
        [DisplayName("Editor")]
        public UserDTO? Editor { get; set; }

        [Required(ErrorMessage = "The News Category is required")]
        [DisplayName("News Category")]
        public NewsCategoryDTO? NewsCategory { get; set; }

        [DisplayName("News Subcategories")]
        public ICollection<NewsSubcategoryDTO>? NewsSubcategories { get; set; }

        //[DisplayName("Favorited By")]
        //public ICollection<ReaderUserDTO>? FavoritedBy { get; set; }
    }
}
