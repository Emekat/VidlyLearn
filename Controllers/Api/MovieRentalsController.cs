using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using VidlyLearn.Dtos;
using VidlyLearn.Models;

namespace VidlyLearn.Controllers.Api
{
    public class MovieRentalsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MovieRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            //load customer
            var customer = _context.Customers
                           .SingleOrDefault(customers => customers.Id == newRentalDto.CustomerId);
            
            //List<Movie> movies = new List<Movie>();

            //foreach (var movieId in newRentalDto.MovieIds)
            //{
            //    var movie = _context.Movies.SingleOrDefault(m => m.Id == movieId);
            //    if (movie != null)
            //    {
            //        movies.Add(movie);
            //    }
            //}

            var movies = _context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id));

            var dateRented = DateTime.UtcNow;
            foreach (var movie in movies)
            {
                //customerid and movieid is not necessary
                _context.MovieRentals.Add(new MovieRental
                {
                    Movie = movie,
                    MovieId = movie.Id,
                    CustomerId = customer.Id,
                    Customer = customer,
                    DateRented = dateRented
                });

                _context.SaveChanges();
            }

            return Ok();
        }
    }
}
