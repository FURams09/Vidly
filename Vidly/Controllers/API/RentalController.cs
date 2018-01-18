using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.Controllers.API
{
	public class RentalController : ApiController
	{
		private ApplicationDbContext _context;

		public RentalController()
		{
			_context = new ApplicationDbContext();
		}
		// POST api/<controller>
		[HttpPost]
		public IHttpActionResult RentMovie(RentalDTO rental)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.ID == rental.CustomerID);
			var movies = _context.Movies.Where(m => rental.MovieID.Contains(m.ID)).ToList();

			if ( customer == null)
			{
				return BadRequest("CustomerID is not valid.");
			}
			if (movies.Count <= 0)
			{
				return BadRequest("No Movies Found.");
			};

			if (movies.Count != rental.MovieID.Count())
			{
				return BadRequest("One or More Movie has an invalid ID");
			}


			foreach (var movie in movies)
			{
				if (movie.NoAvailable == 0)
					return BadRequest(movie.Name + " is not available");

				movie.NumberInStock--;

				var newRental = new Rental
				{
					Customer = customer,
					Movie = movie,
					DateRented = DateTime.Now
				};

				_context.Rentals.Add(newRental);
			}
			_context.SaveChanges();

			return Ok();
		}
	}
}