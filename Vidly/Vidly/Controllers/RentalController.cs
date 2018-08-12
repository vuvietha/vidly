using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class RentalController : Controller
    {
        private ApplicationDbContext _context;
        public RentalController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Rental
        public ActionResult Index()
        {
            NewRentalDTO rental = new NewRentalDTO();
            var movies = _context.Movies.ToList();
            rental.Movies = movies;
            rental.Movies.AsEnumerable().Select(o => new MovieModel
            {
                Id = o.Id,
                Name = o.Name
            });
            return View("RentalForm", rental);
        }

        public ActionResult Create(NewRentalDTO rentalDTO)
        {
            if (!ModelState.IsValid)
            {
                var movieLst = _context.Movies.ToList();
                rentalDTO.Movies = movieLst;
                rentalDTO.Movies.AsEnumerable().Select(o => new MovieModel
                {
                    Id = o.Id,
                    Name = o.Name
                });
                return View("RentalForm", rentalDTO);
            }

            
            var customerAdd = _context.Customers.SingleOrDefault(c => c.Id == rentalDTO.CustomerId);
            if (customerAdd != null)
            {
                foreach (var movie in rentalDTO.MovieIds)
                {
                    Rental rental = new Rental();
                    rental.customer = customerAdd;
                    //int id = int.Parse(movie);
                    rental.movie = _context.Movies.SingleOrDefault(c => c.Id == movie);
                    rental.DateRented = DateTime.Now;
                    _context.Rentals.Add(rental);                  

                }
                _context.SaveChanges();              
            }
           
            var movies = _context.Movies.ToList();
            rentalDTO.Movies = movies;
            rentalDTO.Movies.AsEnumerable().Select(o => new MovieModel
            {
                Id = o.Id,
                Name = o.Name
            });

            return View("RentalForm", rentalDTO);
        }
    }
}