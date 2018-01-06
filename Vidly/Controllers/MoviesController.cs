using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;
using Vidly.ViewModels;


namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{

		private ApplicationDbContext _context;

		public MoviesController()
		{
			_context = new ApplicationDbContext();
		}
        // GET: Movies/Random
        public ActionResult Random()
        {
			var movie = new Movie() { Name= "Shrek!" };

			var customers = new List<Customer>
			{
				new Customer  { Name = "Customer 1" },
				new Customer { Name = "Customer 2" }
			};

			var viewModel = new RandomMovieViewModel
			{
				Movie = movie,
				Customers = customers
			};
            return View(viewModel);
        }

		[Route(@"movies/released/{year}/{month:regex(\d{4}):range(1,12)}")]
		public ActionResult ByReleaseDate(int year, int month)
		{
			return Content(year + "/" + month);
		}

		public ActionResult Index()
		{
			var movies = _context.Movies.Include(c => c.Genre);

			return View(movies);
		}

		public ActionResult New()
		{
			var viewModel = new MovieViewModel
			{
				Genre = _context.Genre.ToList()
			};
			return View("MovieForm", viewModel);
		}

		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Save(Movie movie)
		{

			if (movie.ID == 0)
			{
				_context.Movies.Add(movie);
			}
			else
			{
				var movieToUpdate = _context.Movies.Single(c => c.ID == movie.ID);

				movieToUpdate.Name = movie.Name;
				movieToUpdate.ReleaseDate = movie.ReleaseDate;
				movieToUpdate.DateAdded = movie.DateAdded;
				movieToUpdate.GenreId = movie.GenreId;
				movieToUpdate.NoAvailable = movie.NoAvailable;
			}

			if (!ModelState.IsValid)
			{
				var viewModel = new MovieViewModel(movie)
				{
					Genre = _context.Genre.ToList()
				};
				return View("MovieForm", viewModel);
			};
			_context.SaveChanges();
			return RedirectToAction("Index", "Movies");
		}

		public ViewResult Edit(int id)
		{
			var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.ID == id);
			var viewModel = new MovieViewModel(movie)
			{
				Genre = _context.Genre.ToList()
			};
			return View("MovieForm", viewModel);
		}
    }
} 