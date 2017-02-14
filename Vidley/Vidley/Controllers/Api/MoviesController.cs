using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidley.Dtos;
using Vidley.Models;

namespace Vidley.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET api/<controller>
        public IHttpActionResult GetMovies()
        {
            var movies = _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movies);
        }

        // GET api/<controller>/5
        public IHttpActionResult GetMovies(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                NotFound();
            }

            return Ok(movie);
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movie);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Put(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }

            var movieInDb = _context.Movies.FirstOrDefault(m => m.Id == id);

            if (movieInDb == null)
            {
                NotFound();
            }

            

            Mapper.Map(movieDto, movieInDb);
            

            _context.SaveChanges();

        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public void Delete(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                NotFound();
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}