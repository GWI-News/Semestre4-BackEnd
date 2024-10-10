using GwiNews.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GwiNews.Application.DTOs
{
    public class UserDTO
    {
        [Required(ErrorMessage = "O Id é obrigatório.")]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [MaxLength(255, ErrorMessage = "O nome completo pode ter no máximo 255 caracteres.")]
        [DisplayName("Nome Completo")]
        public string? CompleteName { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [MaxLength(255, ErrorMessage = "O e-mail pode ter no máximo 255 caracteres.")]
        [EmailAddress(ErrorMessage = "O e-mail deve ser válido.")]
        [DisplayName("E-mail")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MaxLength(255, ErrorMessage = "A senha pode ter no máximo 255 caracteres.")]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")]
        [DisplayName("Senha")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "O papel do usuário é obrigatório.")]
        [DisplayName("Função")]
        public UserRole? Role { get; set; }

        [Required(ErrorMessage = "O status do usuário é obrigatório.")]
        [DisplayName("Status")]
        public bool? Status { get; set; }
    }
}
