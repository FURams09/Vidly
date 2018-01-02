using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
		// GET: Customer
		public ActionResult Index()
		{ 
			var staticCustomersView = GetCustomers();
            return View(staticCustomersView);
        }

		public ActionResult Details(int id)
		{
			var customer = GetCustomers().SingleOrDefault(c => c.ID == id);
			return View(customer);
		}

		private IEnumerable<Customer> GetCustomers()
		{
			return new List<Customer>
			{
				new Customer {ID = 1, Name = "John Smith" },
				new Customer {ID = 2, Name = "Mary Williams" }
			};
		}

    }
}