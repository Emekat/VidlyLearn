using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyLearn.Models;
using VidlyLearn.ViewModels;

namespace VidlyLearn.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie { Name = "Shrek" };
            var movies = GetMovies();
            var customers = new List<Customer>()
            {
                new Customer {Id = 1, Name = "Emy"},
                new Customer {Id = 2, Name = "Emeka"}
            };
            var viewModel = new RandomMovieVM()
            {
                Customers = customers,
                Movie = movie,
                Movies = movies
            };
            return View(viewModel);
        }

        // GET: Movies/Random
        public ActionResult Edit(int id)
        {
            return Content("id="+id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Quarantine" }
            };
        }
        // GET: Movies/Random
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (string.IsNullOrEmpty(sortBy))
                sortBy = "Name";

            return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));


        }

        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }



    }
}