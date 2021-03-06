﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.DTO
{
	public class CustomerDTO
	{
		public int ID { get; set; }

		[Required(ErrorMessage = "Please enter customer's name.")]
		[StringLength(255)]
		public string Name { get; set; }

		public bool IsSubscribedToNewsletter { get; set; }

		//[Min18YearsIfAMember]
		public DateTime? Birthdate { get; set; }

		public byte MembershipTypeId { get; set; }

		public MembershipTypeDTO MembershipType { get; set; }
	}
}
