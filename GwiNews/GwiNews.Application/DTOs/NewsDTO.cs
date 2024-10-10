using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GwiNews.Application.DTOs
{
    public class NewsDTO
    {
        /// <summary>
        /// Identificador único da notícia.
        /// </summary>
        [Required(ErrorMessage = "Id is required.")]
        public Guid Id { get; set; }

        /// <summary>
        /// Status da notícia (0 - Publicada, 1 - Em Revisão, 2 - Rascunho, 3 - Inativa).
        /// </summary>
        [Required(ErrorMessage = "Status is required.")]
        public NewsStatus Status { get; set; }

        /// <summary>
        /// Link da notícia completa.
        /// </summary>
        [MaxLength(255, ErrorMessage = "NewsUrl cannot exceed 255 characters.")]
        public string NewsUrl { get; set; }

        /// <summary>
        /// Título da notícia.
        /// </summary>
        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(75, ErrorMessage = "Title cannot exceed 75 characters.")]
        public string Title { get; set; }

        /// <summary>
        /// Subtítulo da notícia.
        /// </summary>
        [MaxLength(255, ErrorMessage = "Subtitle cannot exceed 255 characters.")]
        public string Subtitle { get; set; }

        /// <summary>
        /// Corpo da notícia.
        /// </summary>
        [MaxLength(65535, ErrorMessage = "NewsBody cannot exceed 65,535 characters.")]
        public string NewsBody { get; set; }

        /// <summary>
        /// URL da imagem da notícia.
        /// </summary>
        [MaxLength(555, ErrorMessage = "ImageUrl cannot exceed 555 characters.")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Data de publicação da notícia.
        /// </summary>
        [Required(ErrorMessage = "PublicationDate is required.")]
        public DateTime PublicationDate { get; set; }

        /// <summary>
        /// Autor da notícia.
        /// </summary>
        /// 
        /*public UserWithNews Author { get; set; }

        /// <summary>
        /// Editor da notícia.
        /// </summary>
        public UserWithNews Editor { get; set; }

        /// <summary>
        /// Categoria da notícia.
        /// </summary>
        public NewsCategory NewsCategory { get; set; }

        /// <summary>
        /// Subcategorias da notícia.
        /// </summary>
        public ICollection<NewsSubcategory> NewsSubcategories { get; set; }

        /// <summary>
        /// Usuários que favoritaram a notícia.
        /// </summary>
        public ICollection<ReaderUser> FavoritedByUsers { get; set; }*/
    }

    /// <summary>
    /// Enumeração dos Status da Notícia.
    /// </summary>
    public enum NewsStatus
    {
        Publicada = 0,
        EmRevisao = 1,
        Rascunho = 2,
        Inativa = 3
    }
}
