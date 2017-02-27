using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidley.Models;
using Vidley.ViewModels;

namespace Vidley.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek! "};
            
            var customers = new List<Customer>()
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            //return Content("Hello world");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new {page = 1, sortBy = "Name"});

        }

        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }
            return View("ReadOnlyList");
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Create()
        {
            var genres = _context.Genres.ToList();
            var movie = new Movie();
            var viewModel = new EditMovieViewModel(movie)
            {
                Genres = genres
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            movie.DateAdded = DateTime.Now;
            if (!ModelState.IsValid)
            {
                var viewModel = new EditMovieViewModel(movie)
                {
                   Genres = _context.Genres.ToList()
                };
                return RedirectToAction("Update", viewModel);
            }

            
            
            if ( movie.Id == 0)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(i => i.Genre).SingleOrDefault(x => x.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewNodel = new EditMovieViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewNodel);
        }

        [HttpPost]
        public ActionResult Update(Movie movie)
        {
            var movieInDb = _context.Movies.SingleOrDefault(x => x.Id == movie.Id);

            if (movieInDb == null)
            {
                return HttpNotFound();
            }
            else
            {
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                //movieInDb.DateAdded = movie.DateAdded;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}