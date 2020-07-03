using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyLearn.Models;

namespace VidlyLearn.ViewModels
{
    public class RandomMovieVM
    {
        public Movie Movie { get; set; }
        public List<Movie> Movies { get; set; }
        public List<Customer> Customers { get; set; }


    }
}