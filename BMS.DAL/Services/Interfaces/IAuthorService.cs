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
		public Task<IQueryable<Author>> GetAll(params string[] includes);
		public  Task<Author> Get(int id);
		public Task<Author> Update(AuthorDto dto,int id);
		public Author Delete(int id);
	}
}
