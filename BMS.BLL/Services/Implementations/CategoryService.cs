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

namespace BMS.BLL.Services.Implementations
{
	public class CategoryService : ICategoryService
	{
		private readonly IGenericRepository<Category> _categoryRepository;
		private readonly IMapper _mapper;
		public CategoryService(IGenericRepository<Category> categoryRepository,
			IMapper mapper)
		{
			_categoryRepository = categoryRepository;
			_mapper = mapper;
		}
		public async Task<CategoryDto> Add(CategoryDto dto)
		{
			Category category = _mapper.Map<Category>(dto);
			await _categoryRepository.Add(category);
			await _categoryRepository.SaveAsync();
			return dto;
		}

		public Category Delete(int id)
		{
		return _categoryRepository.Delete(id);
		}

		public async Task<Category> Get(int id, params string[] includes)
		{
			return await _categoryRepository.Get(id, includes);
		}

		public async Task<IQueryable<Category>> GetAll(params string[] includes)
		{
			return await _categoryRepository.GetAll(includes);
		}

		public async Task<Category> Update(CategoryDto dto, int id)
		{
		var category= await Get(id);
			category.Name= dto.Name;
			return _categoryRepository.Update(category);
		}
	}
}
