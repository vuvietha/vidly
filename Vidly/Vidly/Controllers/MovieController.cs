using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movie
        public ActionResult Random()
        {
            var movie = new MovieModel { Name = "Sherk" };
            //return View(movie);
            //return Content("HelloWorld");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "Name" });
            //ViewData["movie"] = movie;
            // ViewBag.RandomMovie = movie;
            var customers = new List<CustomerModel>
           {
               new CustomerModel {Name = "customer 1" },
               new CustomerModel {Name = "customer 2" }
           };
            RandomMovieViewModel randomMovieViewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(randomMovieViewModel);

        }

        public ActionResult Edit(int id)
        {
            return Content("id : " + id);
        
        }
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genere).ToList();
            return View(movies);

        }
        public ActionResult Detail(int id)
        {
            var movie = _context.Movies.Include(m => m.Genere).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }
        //public ActionResult Index (int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";
        //    return Content(string.Format("PageIndex = {0} & SortBy={1}", pageIndex, sortBy));
        //}
        [Route("movie/released/{year}/{month:regex(\\d{2})}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(string.Format("{0}/{1}", year, month));
        }
    }
}