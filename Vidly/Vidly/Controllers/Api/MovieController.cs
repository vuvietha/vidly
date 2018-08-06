using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTO;
using Vidly.Models;
using AutoMapper;
using System.Data.Entity;
namespace Vidly.Controllers.Api
{
    public class MovieController : ApiController
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

        //Get /api/movie
        public IHttpActionResult GetMovies()
        {
            var customers = _context.Movies.Include(m => m.Genere).Select(Mapper.Map<MovieModel, MovieDTO>).ToList();
            if (customers.Count == 0)
                return NotFound();

            return Ok(customers);
        }

        //Get /api/movie/1
        public IHttpActionResult GetMovie(int id)
        {
            var customer = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }
       
        //POST /api/movie
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDTO, MovieModel>(movieDTO);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDTO.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDTO);
        }

        //PUT /api/movie
        [HttpPut]
        public IHttpActionResult UpdateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = _context.Movies.SingleOrDefault(m => m.Id == movieDTO.Id);
            Mapper.Map(movieDTO, movie);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDTO);

        }

        //DELETE /api/movie/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok(movie);
        }

    }
}
