using GwiNews.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GwiNews.Application.DTOs
{
    public class NewsDTO
    {
        [Required(ErrorMessage = "Id is required.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public NewsStatus Status { get; set; }

        [MaxLength(255, ErrorMessage = "NewsUrl cannot exceed 255 characters.")]
        public string NewsUrl { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(75, ErrorMessage = "Title cannot exceed 75 characters.")]
        public string Title { get; set; }

        [MaxLength(255, ErrorMessage = "Subtitle cannot exceed 255 characters.")]
        public string Subtitle { get; set; }

        [MaxLength(65535, ErrorMessage = "NewsBody cannot exceed 65,535 characters.")]
        public string NewsBody { get; set; }

        [MaxLength(555, ErrorMessage = "ImageUrl cannot exceed 555 characters.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "PublicationDate is required.")]
        public DateTime PublicationDate { get; set; }

        /*public UserWithNews Author { get; set; }

        public UserWithNews Editor { get; set; }*/

        public NewsCategory NewsCategory { get; set; }

        /*
        public ICollection<NewsSubcategory> NewsSubcategories { get; set; }

        public ICollection<ReaderUser> FavoritedByUsers { get; set; }*/
    }

    public enum NewsStatus
    {
        Publicada = 0,
        EmRevisao = 1,
        Rascunho = 2,
        Inativa = 3
    }
}
