namespace GwiNews.Domain.Entities
{
    public class ReaderUser : User
    {
        public ICollection<News>? FavoritedNews { get; private set; }
        public ICollection<ProfessionalInformation>? ProfessionalInformations { get; private set; }
        public ICollection<Formation>? Formations { get; private set; }
        public ICollection<ProfessionalSkill>? ProfessionalSkills { get; private set; }

        public ReaderUser(UserRole? role, string? completeName, string? email, string? password, bool? status, ICollection<News>? favoritedNews, ICollection<ProfessionalInformation>? professionalInformations, ICollection<Formation>? formations, ICollection<ProfessionalSkill>? professionalSkills)
            : base(role, completeName, email, password, status)
        {
            FavoritedNews = favoritedNews;
            ProfessionalInformations = professionalInformations;
            Formations = formations;
            ProfessionalSkills = professionalSkills;
        }

        public ReaderUser(Guid? id, UserRole? role, string? completeName, string? email, string? password, bool? status, ICollection<News>? favoritedNews, ICollection<ProfessionalInformation>? professionalInformations, ICollection<Formation>? formations, ICollection<ProfessionalSkill>? professionalSkills)
            : base(id, role, completeName, email, password, status)
        {
            FavoritedNews = favoritedNews;
            ProfessionalInformations = professionalInformations;
            Formations = formations;
            ProfessionalSkills = professionalSkills;
        }
    }
}
