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


		public ActionResult Edit (int id)
		{
			return Content("id=" + id);
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

		public ViewResult Details(int id)
		{
			var movies = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.ID == id);

			return View(movies);
		}
    }
} 