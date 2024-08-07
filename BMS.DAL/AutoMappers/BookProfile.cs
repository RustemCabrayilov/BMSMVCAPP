using AutoMapper;
using BMS.DAL.Dtos;
using BMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DAL.AutoMappers
{
	public class BookProfile : Profile
	{
		public BookProfile()
		{
			CreateMap<BookDto, Book>();
			CreateMap<AuthorDto, Author>();
			CreateMap<AuthorContactDto, AuthorContact>();
			CreateMap<AuthorContact,AuthorContactDto>();

		}
	}
}
