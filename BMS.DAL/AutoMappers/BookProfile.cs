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
			CreateMap<Book, BookDto>();
			CreateMap<AuthorDto, Author>();
			CreateMap<Author, AuthorDto>();
			CreateMap<PublisherDto, Publisher>();
			CreateMap<AuthorContactDto, AuthorContact>();
			CreateMap<AuthorContact, AuthorContactDto>();

		}
	}
}
