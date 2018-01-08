using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DTO
{
	public class MovieDTO
	{
		public int ID { get; set; }

		[Required]
		[StringLength(400)]
		public string Name { get; set; }

		[Required]
		public DateTime? ReleaseDate { get; set; }

		[Required]
		public DateTime DateAdded { get; set; }

		[Required]
		[Range(0, 20, ErrorMessage = "Stock must be between 0 and 20.")]
		public short NoAvailable { get; set; }

		[Required]
		public short GenreId { get; set; }

		public GenreDTO genre { get; set; }
	}
}