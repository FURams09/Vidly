using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.DTO;
using Vidly.Models;
namespace Vidly.App_Start
{
	public class MappingProfile : Profile
	{

		public MappingProfile()
		{
			Mapper.CreateMap<Customer, CustomerDTO>()
			.ForMember(c => c.ID, opt => opt.Ignore());
			Mapper.CreateMap<CustomerDTO, Customer>();

			Mapper.CreateMap<Movie, MovieDTO>();
				
			Mapper.CreateMap<MovieDTO, Movie>()
				.ForMember(m => m.ID, opt => opt.Ignore());
		}
		
	}
}