using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwiNews.Application.DTOs
{
    public class NewsCategoryDTO
    {
        [Required(ErrorMessage = "O ID é obrigatório.")]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
        [MaxLength(25, ErrorMessage = "O nome da categoria pode ter no máximo 25 caracteres.")]
        [DisplayName("Nome")]
        public string? Name { get; set; }
    }
}
