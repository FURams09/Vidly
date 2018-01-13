using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using Vidly.Models;
using Vidly.DTO;


namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
		private ApplicationDbContext _context;

		public MoviesController()
		{
			_context = new ApplicationDbContext();
		}

		public IHttpActionResult GetMovies()
		{
			var movieDTO = _context.Movies
				.Include(m => m.Genre)
				.ToList()
				.Select(Mapper.Map<Movie, MovieDTO>);
			return Ok(movieDTO);
		}

		public IHttpActionResult GetMovie(int id)
		{
			var movie = _context.Movies.Single(c => c.ID == id);
			if (movie == null)
				return NotFound();

			return Ok(Mapper.Map<Movie, MovieDTO>(movie));
		}

		[Authorize(Roles = "canManageMovies")]
		[HttpPost]
		public IHttpActionResult AddMovie(MovieDTO movie)
		{
			if (!ModelState.IsValid)
				return BadRequest();
			var movieInDb = Mapper.Map<MovieDTO, Movie>(movie);
			_context.Movies.Add(movieInDb);
			_context.SaveChanges();

			movie.ID = movieInDb.ID;
			return Created(Request.RequestUri + "/" + movie.ID, movie);
		}

		[Authorize(Roles = "canManageMovies")]
		[HttpPut]
		public IHttpActionResult UpdateMovie(int id, MovieDTO movie)
		{
			if (!ModelState.IsValid)
				return BadRequest();
			var movieInDb = _context.Movies.SingleOrDefault(m => m.ID == id);
			Mapper.Map(movie, movieInDb);

			_context.SaveChanges();
			return Ok();


		}

		[Authorize(Roles = "canManageMovies")]
		[HttpDelete]
		public IHttpActionResult DeleteMovie(int id)
		{
			var movieInDb = _context.Movies.SingleOrDefault(m => m.ID == id);

			if (movieInDb == null)
				return BadRequest();

			_context.Movies.Remove(movieInDb);
			_context.SaveChanges();

			return Ok();
		}
    }
}
