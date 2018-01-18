using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.DTO
{
	public class RentalDTO
	{
		public int CustomerID { get; set; }
		public List<int> MovieID { get; set; }
	}
}