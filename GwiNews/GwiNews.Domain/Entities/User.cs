﻿using GwiNews.Domain.Validation;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GwiNews.Domain.Entities
{
    public class User
    {
        public Guid? Id { get; set; }
        [Required]
        public UserRole? Role { get; set; }
        [Required]
        public string? CompleteName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public bool? Status { get; set; }

        public User(UserRole? role, string? completeName, string? email, string? password, bool? status)
        {
            ValidateDomain(role, completeName, email, password, status);
        }

        public User(Guid? id, UserRole? role, string? completeName, string? email, string? password, bool? status)
        {
            if (id == null || id == Guid.Empty)
            {
                throw new DomainExceptionValidation("Id deve ser um GUID válido e não pode ser vazio ou nulo.");
            }
            ValidateDomain(role, completeName, email, password, status);
            Id = id;
        }

        private void ValidateDomain(UserRole? role, string? completeName, string? email, string? password, bool? status)
        {
            DomainExceptionValidation.When(role == null, "O papel do usuário é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(completeName) || completeName.Length > 255, "O nome completo é obrigatório e não pode exceder 255 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(email) || email.Length > 255, "Um e-mail válido é obrigatório e não pode exceder 255 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(password) || password.Length < 6 || password.Length > 255, "A senha deve ter pelo menos 6 caracteres e não pode exceder 255 caracteres.");
            DomainExceptionValidation.When(status == null, "O status é obrigatório.");

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
