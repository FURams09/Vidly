using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Models
{
	public class Min18YearsIfAMember: ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var customer = (Customer)validationContext.ObjectInstance;

			if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo) //One is pay as you go
			{
				return ValidationResult.Success;
			}
			if (customer.Birthdate == null)
			{
				return new ValidationResult("Birthdate is required");
			}

			var age = (DateTime.Today.Year - customer.Birthdate.Value.Year);
			if (age >= 18)
			{
				return ValidationResult.Success;
			}
			else
			{
				return new ValidationResult("Customer Must be 18 to sign up for membership");
			}
		}
	}
}