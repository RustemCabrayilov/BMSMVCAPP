using BMS.DAL.Dtos;
using BMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DAL.Services.Interfaces
{
	public interface ICategoryService
	{
		public Task<PublisherDto> Add(CategoryDto dto);
		public Task<Category> Update(CategoryDto dto, int id);
		public Category Delete(int id);
		public Task<Category> Get(int id, params string[] includes);
		public Task<IQueryable<Category>> GetAll(params string[] includes);
	}
}
