using BMS.DAL.Dtos;
using BMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DAL.Services.Interfaces
{
	public interface IAuthorService
	{
		public Task<AuthorDto> Add(AuthorDto dto);
		public Task<List<Author>> GetAll(params string[] includes);
		public  Task<Author> Get(int id);
	}
}
