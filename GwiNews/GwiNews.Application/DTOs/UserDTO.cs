using GwiNews.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GwiNews.Application.DTOs
{
    public class UserDTO
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "The Role is required")]
        [DisplayName("User Role")]
        public UserRole? Role { get; set; }

        [Required(ErrorMessage = "The Complete Name is required")]
        [StringLength(255, ErrorMessage = "The Complete Name cannot exceed 255 characters")]
        [MinLength(3, ErrorMessage = "The Complete Name must have at least 3 characters")]
        [DisplayName("Complete Name")]
        public string? CompleteName { get; set; }

        [Required(ErrorMessage = "The Email is required")]
        [EmailAddress(ErrorMessage = "A valid Email is required")]
        [StringLength(255, ErrorMessage = "The Email cannot exceed 255 characters")]
        [DisplayName("Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "The Password is required")]
        [PasswordPropertyText]
        [StringLength(255, ErrorMessage = "The Password cannot exceed 255 characters")]
        [MinLength(6, ErrorMessage = "The Password must have at least 6 characters")]
        [DisplayName("Password")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "The Status is required")]
        [DisplayName("Status")]
        public bool? Status { get; set; }

        [DisplayName("User Active")]
        public bool IsActive => Status == true;
    }
}
