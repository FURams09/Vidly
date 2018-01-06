using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
	public class MovieViewModel
	{
		public IEnumerable<Genre> Genre { get; set; }

		public int ID { get; set; }

		[Required]
		[StringLength(400)]
		public string Name { get; set; }

		[Required]
		[Display(Name = "Release Date")]
		public DateTime? ReleaseDate { get; set; }

		[Required]
		[Display(Name = "Date Added")]
		public DateTime? DateAdded { get; set; }

		[Required]
		[Display(Name = "# in Stock")]
		[Range(0, 20, ErrorMessage = "Stock must be between 0 and 20.")]
		public short? NoAvailable { get; set; }

		[Required]
		[Display(Name = "Genre")]
		public short? GenreId { get; set; }


		public string Title
		{
			get
			{
				return ID != 0 ? "Edit Movie" : "New Movie";
			}
		}


		public MovieViewModel()
		{
			ID = 0;
		}
		public MovieViewModel(Movie movie)
		{
			ID = movie.ID;
			Name = movie.Name;
			GenreId = movie.GenreId;
			ReleaseDate = movie.ReleaseDate;
			NoAvailable = movie.NoAvailable;
			DateAdded = movie.DateAdded;
		}
	}
}