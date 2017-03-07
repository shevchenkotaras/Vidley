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
            int customerId = newRental.CustomerId;
            Customer customerInDb = _dbContext.Customers.Single(x => x.Id == customerId);
            
            var movies = _dbContext.Movies.Where(m => newRental.MovieIds.Contains(m.Id));

            foreach (var movie in movies)
            {
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