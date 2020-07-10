
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VidlyLearn.Models
{
    public class Movie
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
        [Range(1,20)]
        public byte NumberInStock { get; set; }
        [DisplayName("Number in Stock")]
        [Required]
        [Range(1, 20)]
        public byte NumberAvailable { get; set; }


    }
}