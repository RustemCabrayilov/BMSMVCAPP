using BMS.DAL.Dtos;
using BMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DAL.Services.Interfaces
{
	public interface IBookService
	{
		public  Task<BookDto> Add(BookDto dto);
		public Task<IQueryable<Book>> GetAll(params string[] includes);
	}
}
