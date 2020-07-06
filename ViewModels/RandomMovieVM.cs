using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyLearn.Models;

namespace VidlyLearn.ViewModels
{
    public class RandomMovieVM
    {
        public RandomMovieVM()
        {
            Id = 0;
        }
        public RandomMovieVM(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;

        }
        [Required]
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Required]
        [DisplayName("Genre")]
        public byte? GenreId { get; set; }

        [DisplayName("Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [DisplayName("Number in Stock")]
        [Required]
        [Range(1, 20)]
        public byte? NumberInStock { get; set; }

        public List<Movie> Movies { get; set; }

        public List<Customer> Customers { get; set; }

        public List<Genre> Genres { get; set; }
        public Genre Genre { get; set; }

        public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edit Movie";
                return "New Movie";
            }
        }
    }
}