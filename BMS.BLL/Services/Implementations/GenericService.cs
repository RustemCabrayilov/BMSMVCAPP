using BMS.DAL.Data;
using BMS.DAL.Models;
using BMS.DAL.Repository;
using BMS.DAL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.BLL.Services.Implementations
{
	public class GenericService<T>:IGenericService<T> where T : BaseEntity,new()
	{
	private readonly IGenericRepository<T> _genericRepository;
		public GenericService(IGenericRepository<T> genericRepository)
		{
			_genericRepository = genericRepository;
		}
		public async Task<T> Add(T entity)
		{
		await _genericRepository.Add(entity);
			return entity;
		}

		public T Delete(int id)
		{
			return _genericRepository.Delete(id);
		}

		public async Task<T> Get(int id)
		{
			var entity = await _genericRepository.Get(id);
			return entity;
		}

		public async Task<List<T>> GetAll(params string[] includes)
		{
			return  _genericRepository.GetAll(includes).Result.ToList();
		}

		public T Update(T entity)
		{
			_genericRepository.Update(entity);
			return entity;
		}
	}
}
