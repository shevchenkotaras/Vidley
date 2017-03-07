using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vidley.Dtos;
using Vidley.Models;
using Vidley.ViewModels;

namespace Vidley.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public RentalsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult GetRental(NewRentalDto newRental)
        {
            if (newRental.MovieIds.Count == 0)
                return BadRequest("No movie ids have been given");

            int customerId = newRental.CustomerId;
            Customer customerInDb = _dbContext.Customers.SingleOrDefault(x => x.Id == customerId);

            if (customerInDb == null)
                return BadRequest("CustomerId is not valid");
            
            List<Movie> movies = _dbContext.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or more movies are invalid");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rental()
                {
                    Customer = customerInDb,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _dbContext.Rentals.Add(rental);
                
            }
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}