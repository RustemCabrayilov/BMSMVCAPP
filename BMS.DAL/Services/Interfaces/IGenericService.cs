using BMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DAL.Services.Interfaces
{
	public interface IGenericService<T> where T : BaseEntity, new()
	{
		public Task<T> Add(T entity);
		public T Update(T entity);
		public T Delete(int id);
		public Task<T> Get(int id);
		public Task<List<T>> GetAll(params string[] includes);
		
	}
}
