using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [HttpGet]
        public IHttpActionResult GetRental()
        {
            var rentals = _context.Rentals.Include(c => c.customer).Include( c=> c.movie).ToList();
            if (rentals != null)
            {
                return Ok(rentals);
            }
            return NotFound();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDTO newRentalDTO)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRentalDTO.CustomerId);
            if (customer != null)
            {
                var movies = _context.Movies.Where(m => newRentalDTO.MovieIds.Contains(m.Id));
                foreach (var movie in movies)
                {
                    Rental rental = new Rental
                    {
                        customer = customer,
                        movie = movie,
                        DateRented = DateTime.Now

                    };
                    _context.Rentals.Add(rental);


                }
                _context.SaveChanges();
            }
                    
            return Created("RentalForm",newRentalDTO);
        }
    }
}
