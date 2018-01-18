using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Models;
using Vidly.DTO;
using System.Data.Entity;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
		private ApplicationDbContext _context;

		public CustomersController()
		{
			_context = new ApplicationDbContext();
		}
		// Get /api/customers by convetion
		public IHttpActionResult GetCustomers(string query = null)
		{
			var customersQuery = _context.Customers
				.Include(c => c.MembershipType);
			if (!String.IsNullOrWhiteSpace(query))
				customersQuery = customersQuery.Where(c => c.Name.Contains(query));

			var customerDTOS = customersQuery
				.ToList()
				.Select(Mapper.Map<Customer, CustomerDTO>);
			return Ok(customerDTOS);
		}

		// Get /api/customers/{id} by convention
		public IHttpActionResult GetCustomer(int id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.ID == id);

			if (customer == null)
			{
				return NotFound();
			}

			return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
		}

		// Post /api/customers
		// specify [HttpPost] since we don't use the convention recommended name of PostCustomer
		[HttpPost]
		public IHttpActionResult CreateCustomer(CustomerDTO customerDTO)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
			_context.Customers.Add(customer);
			_context.SaveChanges();


			customerDTO.ID = customer.ID;
			return Created(new Uri(Request.RequestUri + "/" + customer.ID), customerDTO);
			
		}

		//Put /api/customers/{id}
		[HttpPut]
		public void UpdateCustomer(int id, CustomerDTO customerDTO)
		{
			if (!ModelState.IsValid)
				throw new HttpResponseException(HttpStatusCode.BadRequest);
			var customerInDb = _context.Customers.Single(c => c.ID == id);

			if (customerInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);
			Mapper.Map<CustomerDTO, Customer>(customerDTO, customerInDb); //pass customerInDb as last parameter so that the ApplicationDBContext can keep track of changes made to it when the CustomerDTO values are mapped to it. 

			_context.SaveChanges();
				
		}

		[HttpDelete]
		public void DeleteCustomer(int id)
		{
			var customerInDb = _context.Customers.Single(c => c.ID == id);

			if (customerInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			_context.Customers.Remove(customerInDb);
			_context.SaveChanges();
		}
    }
}
