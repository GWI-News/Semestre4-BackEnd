namespace GwiNews.Domain.Entities
{
    public class User
    {
        public Guid? Id { get; set; }
        public UserRole? Role { get; set; }
        public string? CompleteName { get; set; }
        public string? Email {  get; set; }
        public string? Password { get; set; }
        public bool? Status { get; set; }

        public User(Guid? id, UserRole? role, string? completeName, string? email, string? password, bool? status)
        {
            Id = id;
            Role = role;
            CompleteName = completeName;
            Email = email;
            Password = password;
            Status = status;
        }
    }

    public enum UserRole
    {
        Administrador = 0,
        Editor = 1,
        Autor = 2,
        Leitor = 3
    }
}
