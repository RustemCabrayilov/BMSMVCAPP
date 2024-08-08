using AutoMapper;
using BMS.DAL.Dtos;
using BMS.DAL.Models;
using BMS.DAL.Repository;
using BMS.DAL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DAL.Services.Implementations
{
	public class CategoryService : ICategoryService
	{
		private readonly IGenericRepository<Category> _categoryService;
		private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> categoryService,
			IMapper mapper)
        {
            _categoryService = categoryService;
			_mapper = mapper;
        }
        public Task<PublisherDto> Add(CategoryDto dto)
		{
			throw new NotImplementedException();
		}

		public Category Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Category> Get(int id, params string[] includes)
		{
			throw new NotImplementedException();
		}

		public Task<IQueryable<Category>> GetAll(params string[] includes)
		{
			return _categoryService.GetAll(includes);
		}

		public Task<Category> Update(CategoryDto dto, int id)
		{
			throw new NotImplementedException();
		}
	}
}
