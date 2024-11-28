using GwiNews.Application.DTOs;

namespace GwiNews.Application.DTOs
{
    public class ReaderUserDTO : UserDTO
    {
        [DisplayName("Notícias Favoritadas")]
        public ICollection<NewsDTO> FavoritedNews { get; set; }

        [DisplayName("Informações Profissionais")]
        public ICollection<ProfessionalInformationDTO> ProfessionalInformations { get; set; }

        [DisplayName("Habilidades Profissionais")]
        public ICollection<ProfessionalSkillDTO> ProfessionalSkills { get; set; }

        [DisplayName("Formações Acadêmicas")]
        public ICollection<FormationDTO> Formations { get; set; }
    }
}
