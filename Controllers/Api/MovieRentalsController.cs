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
                           .Single(customers => customers.Id == newRentalDto.CustomerId);

            var movies = _context.Movies
                .Where(m => newRentalDto.MovieIds.Contains(m.Id)).ToList();

            var dateRented = DateTime.Now;
          
            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie Is Not Available");

                //customerid and movieid is not necessary
                movie.NumberAvailable--;
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
