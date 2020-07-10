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
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
       
        // GET: Movies/Random
        public ActionResult Index()
        { 
            if(User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            return View("ReadOnlyList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieVM(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            //new movie
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                movie.NumberAvailable = movie.NumberInStock;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDB = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDB.Name = movie.Name;
                movieInDB.ReleaseDate = movie.ReleaseDate;
                movieInDB.NumberInStock = movie.NumberInStock;
                movieInDB.NumberAvailable = movie.NumberInStock;
                movieInDB.GenreId = movie.GenreId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieVM(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult MovieForm()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieVM()
            {
                Genres = genres
            };
            return View("MovieForm",viewModel);
        }
        // GET: Customers/Details
        // [Route("Customers/Details")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.Id == id);

            var viewModel = new MovieVM(movie)
            {
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