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
		public  Task<Book> Update(BookDto dto, int id);
		public Book Delete(int id);
		public  Task<Book> Get(int id, params string[] includes);
	}
}
