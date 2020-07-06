using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using VidlyLearn.Models;
using VidlyLearn.ViewModels;

namespace VidlyLearn.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
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

            // return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

            var movies = _context.Movies.Include(g => g.Genre).ToList();
           
            var viewModel = new RandomMovieVM()
            {
               
                Movies = movies
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDB = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDB.Name = movie.Name;
                movieInDB.ReleaseDate = movie.ReleaseDate;
                movieInDB.DateAdded = movie.DateAdded;
                movieInDB.NumberInStock = movie.NumberInStock;
                movieInDB.GenreId = movie.GenreId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();
            var viewModel = new RandomMovieVM()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MoviesForm", viewModel);
        }

        public ActionResult New()
        {

            var genres = _context.Genres.ToList();
            var viewModel = new RandomMovieVM()
            {
                Genres = genres

            };
            return View("MoviesForm",viewModel);
        }
        // GET: Customers/Details
        // [Route("Customers/Details")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.Id == id);

            var viewModel = new RandomMovieVM()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            if (movie == null)
                return HttpNotFound();
            return View(viewModel);
        }



        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}