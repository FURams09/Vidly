using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
	public class Genre
	{
		public short ID { get; set; }
		[StringLength(100)]
		public string GenreName { get; set; }
	}
}