using System.ComponentModel;

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
}
