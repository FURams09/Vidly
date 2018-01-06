using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Vidly.Models
{
	public class Movie
	{
		public int ID { get; set; }

		[Required]
		[StringLength(400)]
		public string Name { get; set; }

		[Required]
		[Display(Name="Release Date")]
		public DateTime? ReleaseDate { get; set; }

		[Required]
		[Display(Name ="Date Added")]
		public DateTime DateAdded { get; set; }

		[Required]
		[Display(Name ="# in Stock")]
		[Range(0, 20, ErrorMessage = "Stock must be between 0 and 20.")]
		public short NoAvailable { get; set; }

		public Genre Genre { get; set; }

		[Required]
		[Display(Name="Genre")]
		public short GenreId { get; set; }

	}
}