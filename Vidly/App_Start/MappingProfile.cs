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
			var customerCustomerDTOconfig = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Customer, CustomerDTO>();
			});
			var movieMovieDTOconfig = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Movie, MovieDTO>();
			});
			var membershipTypeMembershipTypeIDconfig = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<MembershipType, MembershipTypeDTO>();
			});
			var genreGenreDTOconfig = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Genre, GenreDTO>();
			});

			var customerDTOCustomerconfig = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<CustomerDTO, Customer>()
				.ForMember(c => c.ID, opt => opt.Ignore());
			});
			var movieDTOMovieconfig = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<MovieDTO, Movie>()
				.ForMember(c => c.ID, opt => opt.Ignore());
			});

		}
		
	}
}