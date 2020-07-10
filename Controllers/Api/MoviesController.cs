using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using VidlyLearn.Dtos;
using VidlyLearn.Models;

namespace VidlyLearn.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/movies
        public IHttpActionResult GetMovies(string query= null)
        {
            //get available movies first
            var moviesQuery = _context.Movies
                .Include(g => g.Genre)
                .Where(m => m.NumberAvailable > 0);

            if (!string.IsNullOrEmpty(query))
            {
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));
            }

            var moviesDto = moviesQuery
               
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
           
            return Ok(moviesDto);
        }

        //GET /api/movies/1
        public IHttpActionResult GetMovies(int id)
        {
            var movie = _context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        //DELETE /api/movies/1
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteMovies(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok();
        }

   
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateMovies(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movieDto.Id), movieDto);
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateMovies(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();
            return Ok(movieDto);
        }

    }
}
