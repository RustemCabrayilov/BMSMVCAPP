using BMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DAL.Repository
{
    public interface IGenericRepository<T> where T : new()
    {
        public Task <T> Add(T entity);
        public T Update(T entity);
        public T Delete(int id);
        public Task<T> Get(int id,params string[] includes);
        public Task<IQueryable<T>> GetAll(params string[] includes);
        public Task  SaveAsync();

	}
}
