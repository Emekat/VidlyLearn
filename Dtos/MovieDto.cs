using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyLearn.Models;

namespace VidlyLearn.Dtos
{
    public class MovieDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [DisplayName("Genre")]
        public byte GenreId { get; set; }

        [DisplayName("Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [DisplayName("Number in Stock")]
        [Required]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }

    }
}