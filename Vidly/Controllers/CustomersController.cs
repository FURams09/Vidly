using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

		private ApplicationDbContext _context;

		public CustomersController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		// GET: Customer
		public ActionResult Index()
		{
			//commented code was used before we created the table with api and jQuery datatables
			//var customers = _context.Customers.Include(c => c.MembershipType);
			//         return View(customers);
			return View();
        }

		public ActionResult Details(int id)
		{
			var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.ID == id);
			return View(customer);
		}

		public ActionResult New()
		{
			var membershipTypes = _context.MembershipTypes.ToList();

			var viewModel = new CustomerFormViewModel
			{
				Customer = new Customer(),
				MembershipTypes = membershipTypes
			};
			return View("CustomerForm", viewModel);
		}
		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Save(Customer customer)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new CustomerFormViewModel
				{
					Customer = customer,
					MembershipTypes = _context.MembershipTypes.ToList()
				};
				return View("CustomerForm", viewModel);
			}
			else
			{

			};
			if (customer.ID == 0)
			{
				_context.Customers.Add(customer);
			} 
			else
			{
				var customerInDb = _context.Customers.Single(c => c.ID == customer.ID);

				//TryUpdateModel(customerInDb); This will update every field based on the form
				//TryUpdateModel(customerInDb, new string[] { "Name", "Email" }); Will only update the columns listed in the new string array, but is subject to magic strings that won't be updated by ctrl R + ctrl R

				//Use propertys of customerInDb to update the fields
				customerInDb.Name = customer.Name;
				customerInDb.Birthdate = customer.Birthdate;
				customerInDb.MembershipTypeId = customer.MembershipTypeId;
				customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
			}
			
			_context.SaveChanges();
			return RedirectToAction("Index", "Customers");
		}

		public ActionResult Edit(int id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.ID == id);

			if (customer == null)
				return HttpNotFound();

			var viewModel = new CustomerFormViewModel
			{
				Customer = customer,
				MembershipTypes = _context.MembershipTypes.ToList()
			};
			return View("CustomerForm", viewModel);
		}

	}
}